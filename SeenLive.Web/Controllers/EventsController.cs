using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Events;
using SeenLive.Events.Create;
using SeenLive.Events.GetAll;
using SeenLive.Events.GetById;

namespace SeenLive.Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController
        : BaseController
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/events
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllEventsQuery());
            return Ok(response);
        }

        // GET api/events/5
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventViewModel>> FindById([FromRoute] GetEventByIdQuery query)
        {
            var response = await _mediator.Send(query);

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
        public async Task<ActionResult<EventViewModel>> PostAsync([FromBody] CreateEventCommand body)
        {
            var response = await _mediator.Send(body);
            return CreatedAtAction(nameof(FindById), new GetEventByIdQuery { Id = response.Data.Id }, response.Data);
        }
    }
}
