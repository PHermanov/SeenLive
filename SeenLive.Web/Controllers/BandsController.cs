using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Bands;
using SeenLive.Bands.Create;
using SeenLive.Bands.Delete;
using SeenLive.Bands.GetAll;
using SeenLive.Bands.GetById;
using SeenLive.Bands.Update;
using SeenLive.Events;
using SeenLive.Events.GetByBandId;
using SeenLive.Infrastructure;

namespace SeenLive.Api.Controllers
{
    [Route("api/bands")]
    [ApiController]
    public class BandsController
        : BaseController
    {
        private readonly IMediator _mediator;

        public BandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/bands
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BandViewModel>>> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllBandsQuery());
            return Ok(response);
        }

        // GET api/bands/5
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BandViewModel>> FindById([FromRoute] GetBandByIdQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Success 
                ? Ok(response) 
                : ProcessError(response.Error!);
        }

        // POST api/bands
        /// <summary>
        /// Creates new Band
        /// </summary>
        /// <param name="body">JSON with data</param>
        /// <returns>HTTP Status</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BandViewModel>> PostAsync([FromBody] CreateBandCommand body)
        {
            var response = await _mediator.Send(body);
            return CreatedAtAction(nameof(FindById), new GetBandByIdQuery { Id = response.Data.Id }, response.Data);
        }

        //// PUT api/bands/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BandViewModel>> PutAsync([FromRoute] int id, [FromBody] UpdateBandCommand body)
        {
            body.Id = id;

            var response = await _mediator.Send(body);

            return response.Success 
                ? CreatedAtAction(nameof(FindById), new GetBandByIdQuery { Id = response.Data.Id }, response.Data) 
                : ProcessError(response.Error!);
        }

        //// DELETE api/bands/5
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync([FromRoute] DeleteBandCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success 
                ? NoContent() 
                : ProcessError(response.Error!);
        }

        [HttpGet("{Id}/Events")]
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetBandEvents([FromRoute] GetEventByBandIdQuery query)
        {
            var response = await _mediator.Send(query);

            return response.Success 
                ? Ok(response) 
                : ProcessError(response.Error!);
        }
    }
}
