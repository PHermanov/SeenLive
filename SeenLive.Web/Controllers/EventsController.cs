using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Events;
using SeenLive.Events.GetAll;
using SeenLive.Events.GetById;
using SeenLive.Infrastructure;

namespace SeenLive.Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController
        : ControllerBase
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

            if (response.Error == null)
            {
                return Ok(response);
            }

            return response.Error.Type switch
            {
                ErrorType.NotFound => NotFound(),
                _ => Problem()
            };
        }
    }
}
