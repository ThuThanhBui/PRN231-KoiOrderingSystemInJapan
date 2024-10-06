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
    public class ServiceOrdersController : ControllerBase
    {
        private IServiceOrderService serviceOrderService;

        public ServiceOrdersController()
        {
            serviceOrderService ??= new ServiceOrderService();
        }

        // GET: api/ServiceOrders
        [HttpGet]
        public async Task<IBusinessResult> GetServiceOrders()
        {
            return await serviceOrderService.GetAll();
        }

        // GET: api/ServiceOrders/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetServiceOrder(Guid id)
        {
            return await serviceOrderService.GetById(id);

        }

        // PUT: api/ServiceOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutServiceOrder(ServiceOrder serviceOrder)
        {
            return await serviceOrderService.Save(serviceOrder);

        }

        // POST: api/ServiceOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostServiceOrder(ServiceOrder serviceOrder)
        {
            return await serviceOrderService.Save(serviceOrder);

        }

        // DELETE: api/ServiceOrders/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteServiceOrder(Guid id)
        {
            return await serviceOrderService.DeleteById(id);

        }

    }
}
