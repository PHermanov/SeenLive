using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Bands;
using SeenLive.Bands.GetAll;
using SeenLive.Bands.GetById;
using SeenLive.Infrastructure;

namespace SeenLive.Web.Controllers
{
    [Route("api/bands")]
    [ApiController]
    public class BandsController
        : ControllerBase
    {
        private readonly IMediator _mediator;

        public BandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/bands
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BandResourceShort>>> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllBandsQuery());
            return Ok(response);
        }

        // GET api/bands/5
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IHandlerResult<BandViewModel>>> FindById([FromRoute] GetBandByIdQuery query)
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

        // POST api/bands
        /// <summary>
        /// Creates new Band
        /// </summary>
        /// <param name="body">JSON with data</param>
        /// <returns>HTTP Status</returns>

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<BandResourceShort>> PostAsync([FromBody] BandResourceCreate body)
        //{
        //    //var band = _mapper.Map<Band>(body);

        //    //var responce = await _bandService.AddAsync(band);

        //    //if (!responce.Success)
        //    //{

        //    //}

        //    //var createdBandDto = _mapper.Map<BandResourceShort>(responce.Entity);

        //    //return CreatedAtAction(nameof(PostAsync), createdBandDto);
        //}

        //// PUT api/bands/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Put(int id, [FromBody] BandResourceCreate body)
        //{
        //    //throw new NotImplementedException();

        //    //if (id <= 0)
        //    //{
        //    //    return BadRequest("Invalid Id");
        //    //}

        //    //var band = _mapper.Map<Band>(body);
        //}

        //// DELETE api/bands/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
