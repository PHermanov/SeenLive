using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Bands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Controllers
{
    [Route("api/bands")]
    [ApiController]
    public class BandsController
        : ControllerBase
    {
        public BandsController()
        {
            
        }

        // GET: api/bands
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BandResourceShort>>> GetAllAsync()
        {
            //var bands = await _bandService.ListAsync();
            //var bandsDto = _mapper.Map<IEnumerable<BandResourceShort>>(bands);

            //return Ok(bandsDto);

        }

        // GET api/bands/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BandResourceFull>> FindByIdAsyc(int id)
        {
            //var band = await _bandService.FindByIdWithEventsAsync(id);

            //if (band == null)
            //{
            //    return NotFound();
            //}

            //var bandDto = _mapper.Map<BandResourceFull>(band);

            //return Ok(bandDto);
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
        public async Task<ActionResult<BandResourceShort>> PostAsync([FromBody] BandResourceCreate body)
        {
            //var band = _mapper.Map<Band>(body);

            //var responce = await _bandService.AddAsync(band);

            //if (!responce.Success)
            //{
               
            //}

            //var createdBandDto = _mapper.Map<BandResourceShort>(responce.Entity);

            //return CreatedAtAction(nameof(PostAsync), createdBandDto);
        }

        // PUT api/bands/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] BandResourceCreate body)
        {
            //throw new NotImplementedException();

            //if (id <= 0)
            //{
            //    return BadRequest("Invalid Id");
            //}

            //var band = _mapper.Map<Band>(body);
        }

        // DELETE api/bands/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
