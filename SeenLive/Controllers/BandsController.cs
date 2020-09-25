using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Models;
using SeenLive.Resources;
using SeenLive.Services;
using SeenLive.Services.Communication;
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
        private readonly IMapper _mapper;

        public BandsController(IBandService bandService, IMapper mapper)
        {
            _bandService = bandService;
            _mapper = mapper;
        }

        // GET: api/bands
        [HttpGet]
        public async Task<IEnumerable<BandResourceShort>> GetAllAsync()
        {
            var bands = await _bandService.ListAsync();
            return _mapper.Map<IEnumerable<BandResourceShort>>(bands);
        }

        // GET api/bands/5
        [HttpGet("{id}")]
        public async Task<BandResourceFull> FindByIdAsyc(int id)
        {
            var band = await _bandService.FindByIdWithEventsAsync(id);
            return _mapper.Map<BandResourceFull>(band);
        }

        // POST api/bands
        /// <summary>
        /// Creates new Band
        /// </summary>
        /// <param name="band">JSON with data</param>
        /// <returns>HTTP Status</returns>

        [HttpPost]
        public async Task<SaveBandResponce> PostAsync([FromBody] BandResourceCreate bandBody)
        {
            if (!ModelState.IsValid)
            {
                return new SaveBandResponce(string.Join(',', ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage)));
            }
            //return null;

            var band = _mapper.Map<Band>(bandBody);

            var result = await _bandService.AddAsync(band);

            return result;
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
