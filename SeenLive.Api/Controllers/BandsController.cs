using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Bands;
using SeenLive.Bands.Create;
using SeenLive.Bands.CreateOrUpdate;
using SeenLive.Bands.Delete;
using SeenLive.Bands.GetAll;
using SeenLive.Bands.GetById;
using SeenLive.Bands.Update;
using SeenLive.Events;
using SeenLive.Events.GetByBandId;
using SeenLive.Users;

namespace SeenLive.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController
        : BaseController
    {
        private readonly IMediator _mediator;

        public BandsController(IMediator mediator, UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor)
                : base(userManager, httpContextAccessor)
                    => _mediator = mediator;

        // GET: api/bands
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<BandViewModel>>> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllBandsQuery(), HttpContext.RequestAborted);
            return Ok(response);
        }

        // GET api/bands/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BandViewModel>> FindById([FromRoute] GetBandByIdQuery query)
        {
            var response = await _mediator.Send(query, HttpContext.RequestAborted);

            return response.Success
                ? Ok(response)
                : ProcessError(response.Error!);
        }

        // POST api/bands
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<BandViewModel>> PostAsync([FromBody] CreateOrUpdateBandBody body)
        {
            var createCommand = new CreateBandCommand {Body = body};
            var response = await _mediator.Send(createCommand, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(FindById), new GetBandByIdQuery {Id = response.Data.Id}, response.Data);
        }

        //// PUT api/bands/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BandViewModel>> PutAsync([FromRoute] int id,
            [FromBody] CreateOrUpdateBandBody body)
        {
            var updateCommand = new UpdateBandCommand {Id = id, Body = body};
            var response = await _mediator.Send(updateCommand, HttpContext.RequestAborted);

            return response.Success
                ? AcceptedAtAction(nameof(FindById), new GetBandByIdQuery {Id = response.Data.Id}, response.Data)
                : ProcessError(response.Error!);
        }

        //// DELETE api/bands/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] DeleteBandCommand command)
        {
            var response = await _mediator.Send(command, HttpContext.RequestAborted);

            return response.Success
                ? NoContent()
                : ProcessError(response.Error!);
        }

        // GET api/bands/5/events
        [HttpGet("{id:int}/events")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetBandEvents(
            [FromRoute] GetEventByBandIdQuery query)
        {
            var response = await _mediator.Send(query, HttpContext.RequestAborted);

            return response.Success
                ? Ok(response)
                : ProcessError(response.Error!);
        }
    }
}