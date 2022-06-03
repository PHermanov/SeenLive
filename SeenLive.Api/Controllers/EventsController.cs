using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Events;
using SeenLive.Events.AssignBands;
using SeenLive.Events.Create;
using SeenLive.Events.GetAll;
using SeenLive.Events.GetById;
using SeenLive.Infrastructure;
using SeenLive.Users;

namespace SeenLive.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EventsController
    : BaseController
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        : base(userManager, httpContextAccessor)
        => _mediator = mediator;

    // GET: api/events
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<EventViewModel>>> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllEventsQuery(), HttpContext.RequestAborted);
        return Ok(response);
    }

    // GET api/events/5
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventViewModel>> FindById([FromRoute] GetEventByIdQuery query)
    {
        var response = await _mediator.Send(query, HttpContext.RequestAborted);

        return response.Success
            ? Ok(response)
            : ProcessError(response.Error!);
    }

    // POST api/events
    /// <summary>
    /// Creates new Event
    /// </summary>
    /// <param name="body">JSON with data</param>
    /// <returns>HTTP Status</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<EventViewModel>> PostAsync([FromBody] CreateEventCommand body)
    {
        var response = await _mediator.Send(body, HttpContext.RequestAborted);
        return response.Success
            ? CreatedAtAction(nameof(FindById), new GetEventByIdQuery {Id = response.Data.Id}, response.Data)
            : ProcessError(response.Error!);
    }

    //// PUT api/events/5/assign_bands
    [HttpPut("{id:int}/assign_bands")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventViewModel>> AssignBandsToEvent([FromRoute] int id,
        [FromBody] AssignBandsBody body)
    {
        if (id <= 0)
            return ProcessError(new Error
            {
                Message = "EventId must be greater than 0", Field = nameof(AssignBandsCommand.EventId),
                Type = ErrorType.Validation
            });

        var assignBandsCommand = new AssignBandsCommand {EventId = id, Body = body};

        var response = await _mediator.Send(assignBandsCommand, HttpContext.RequestAborted);
        return response.Success
            ? AcceptedAtAction(nameof(FindById), new GetEventByIdQuery {Id = response.Data.Id}, response.Data)
            : ProcessError(response.Error!);
    }
}