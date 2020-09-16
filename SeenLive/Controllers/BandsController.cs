using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Models;
using SeenLive.Resources;
using SeenLive.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeenLive.Controllers
{
    [Route("api/bands")]
    [ApiController]
    public class BandsController
        : ControllerBase
    {
        private readonly IBandService _bandService;

        public BandsController(IBandService bandService) =>
            _bandService = bandService;

        // GET: api/bands
        [HttpGet]
        public async Task<IEnumerable<BandResourceShort>> GetAllAsync() =>
            await _bandService.ListAsync();

        // GET api/bands/5
        [HttpGet("{id}")]
        public async Task<BandResourceFull> FindByIdAsyc(int id)
        {
            var band = await _bandService.FindByIdWithEventsAsync(id);
            var bandResource = Mapper.Map<BandResourceFull>(band);

            return bandResource;
        }

        // POST api/bands
        /// <summary>
        /// Creates new Band
        /// </summary>
        /// <param name="value">JSON with data</param>
        /// <returns>HTTP Status</returns>

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BandResourceCreate value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage));
            }

            var band = Mapper.Map<BandResourceCreate, Band>(value);

            return null;
        }

        // PUT api/bands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/bands/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
