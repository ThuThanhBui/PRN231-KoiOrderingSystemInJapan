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
using KoiOrderingSystemInJapan.Data.Request.KoiOrder;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiOrdersController : ControllerBase
    {
        private readonly KoiOrderService _koiOrderService;

        public KoiOrdersController() => _koiOrderService ??= new KoiOrderService();

        [HttpGet]
        public async Task<IBusinessResult> GetInvoices()
        {
            return await _koiOrderService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetInvoice(Guid id)
        {
            return await _koiOrderService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutInvoice(KoiOrder koiOrder)
        {
            return await _koiOrderService.Save(koiOrder);

        }

        [HttpPost]
        public async Task<IBusinessResult> PostInvoice(KoiOrder koiOrder)
        {
            return await _koiOrderService.Save(koiOrder);
        }
        [HttpPost("create_payment")]
        public async Task<IBusinessResult> CreatePayment(RequestPaymentKoiOrderModel request)
        {
            return await _koiOrderService.CreatePayment(request);
        }

        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteInvoice(Guid id)
        {
            return await _koiOrderService.DeleteById(id);
        }
    }
}
