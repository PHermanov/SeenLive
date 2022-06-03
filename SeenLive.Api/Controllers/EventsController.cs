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
        var response = await _mediator.Send(new GetAllEventsQuery());
        return Ok(response);
    }

    // GET api/events/5
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventViewModel>> FindById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetEventByIdQuery {Id = id});

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
        var response = await _mediator.Send(body);
        return response.Success
            ? CreatedAtAction(nameof(FindById), new GetEventByIdQuery {Id = response.Data.Id}, response.Data)
            : ProcessError(response.Error!);
    }

    //// PUT api/events/5/assign_bands
    [HttpPut("{id:int}/assign_bands")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventViewModel>> AssignBandsToEvent([FromRoute] int id,
        [FromBody] AssignBandsBody body)
    {
        if (id <= 0)
            return BadRequest("EventId must be greater than 0");

        var assignBandsCommand = new AssignBandsCommand {EventId = id, Body = body};

        var response = await _mediator.Send(assignBandsCommand);
        return response.Success
            ? CreatedAtAction(nameof(FindById), new GetEventByIdQuery {Id = response.Data.Id}, response.Data)
            : ProcessError(response.Error!);
    }
}