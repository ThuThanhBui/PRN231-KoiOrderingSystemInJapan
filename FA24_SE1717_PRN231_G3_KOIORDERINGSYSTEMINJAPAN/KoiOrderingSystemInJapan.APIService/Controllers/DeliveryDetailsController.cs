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
    public class DeliveryDetailsController : ControllerBase
    {
      
        private readonly DeliveryDetailService _deliverydetailSerivce;

        public DeliveryDetailsController()
        {
            _deliverydetailSerivce ??= new DeliveryDetailService();
        }

        // GET: api/DeliveryDetails
        [HttpGet]
        public async Task<IBusinessResult> GetDeliveryDetails()
        {
            return await _deliverydetailSerivce.GetAll();
        }

        // GET: api/DeliveryDetails/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetDeliveryDetail(Guid id)
        {
            return await _deliverydetailSerivce.GetById(id);
        }

        // PUT: api/DeliveryDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutDeliveryDetail( DeliveryDetail deliveryDetail)
        {
           
            return await _deliverydetailSerivce.Save(deliveryDetail);
        }

        // POST: api/DeliveryDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            return await _deliverydetailSerivce.Save(deliveryDetail);
        }

        // DELETE: api/DeliveryDetails/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteDeliveryDetail(Guid id)
        {
            return await _deliverydetailSerivce.DeleteById(id);
        }

     
    }
}
