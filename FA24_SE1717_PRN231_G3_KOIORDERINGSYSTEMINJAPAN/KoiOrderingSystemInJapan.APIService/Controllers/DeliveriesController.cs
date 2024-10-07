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
    public class DeliveriesController : ControllerBase
    {
        private readonly KoiTravelShopContext _context;
        private readonly DeliveryService _deliverySerivce;

        public DeliveriesController( )
        {
            _deliverySerivce ??= new DeliveryService();
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<IBusinessResult> GetDeliveries()
        {
            return await _deliverySerivce.GetAll();
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetDelivery(Guid id)
        {
            var delivery = await _deliverySerivce.GetById(id);

            return delivery;
        }

        // PUT: api/Deliveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutDelivery( Delivery delivery)
        {
         
            return await _deliverySerivce.Save(delivery);
        }

        // POST: api/Deliveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostDelivery(Delivery delivery)
        {
            return await _deliverySerivce.Save(delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteDelivery(Guid id)
        {
            return await _deliverySerivce.DeleteById(id);
        }

    }
}
