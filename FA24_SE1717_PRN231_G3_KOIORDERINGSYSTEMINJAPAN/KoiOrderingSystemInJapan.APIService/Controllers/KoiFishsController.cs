using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiFishsController : ControllerBase
    {
        private readonly KoiFishService _fishService;
        public KoiFishsController()
        {
            _fishService ??= new KoiFishService();
        }
        // GET: api/KoiFishs
        [HttpGet]
        public async Task<IBusinessResult> GetKoiFish()
        {
            return await _fishService.GetAll();
        }

        // GET: api/KoiFishs/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetKoiFish(Guid id)
        {
            var fish = await _fishService.GetById(id);

            return fish;
        }

        // PUT: api/KoiFishs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutKoiFish(KoiFish fish)
        {

            return await _fishService.Save(fish);
        }

        // POST: api/KoiFishs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostKoiFish(KoiFish fish)
        {
            return await _fishService.Save(fish);
        }

        // DELETE: api/KoiFishs/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteKoiFish(Guid id)
        {
            return await _fishService.DeleteById(id);
        }
    }
}
