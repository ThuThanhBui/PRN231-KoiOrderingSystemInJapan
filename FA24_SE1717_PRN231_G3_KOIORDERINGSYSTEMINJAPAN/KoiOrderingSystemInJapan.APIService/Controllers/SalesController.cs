using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISaleService saleService;

        public SalesController()
        {
            saleService ??= new SaleService();
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<IBusinessResult> GetSales()
        {
            return await saleService.GetAll();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetSale(Guid id)
        {
            return await saleService.GetById(id);

        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutSale(Sale sale)
        {
            return await saleService.Save(sale);


        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostSale(Sale sale)
        {
            return await saleService.Save(sale);

        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteSale(Guid id)
        {
            return await saleService.DeleteById(id);

        }

    }
}
