using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Common;
using Newtonsoft.Json;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly KoiOrderingSystemInJapanContext _context;

        public DeliveriesController()
        {

        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "Deliveries"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                        if (result != null && result.Data != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<Delivery>>(result.Data.ToString());
                            return View(data);
                        }
                    }
                }
            }
            return View(new List<Delivery>());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "Deliveries/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                        if (result != null && result.Data != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<Delivery>>(result.Data.ToString());
                            return View(data);
                        }
                    }
                }
            }
            return View(new Delivery());
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KoiOrderId,DeliveryStaffId,Code,Name,Phone,Address,TotalAmount,PaymentReceived,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] Delivery delivery)
        {
            #region Save
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "Deliveries/", delivery))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                            if (result != null && result.Status == Const.SUCCESS_CREATE_CODE)
                            {
                                return View(result);
                            }
                            else
                            {
                                return View(delivery);
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Index");
            #endregion
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            return View(id);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,KoiOrderId,DeliveryStaffId,Code,Name,Phone,Address,TotalAmount,PaymentReceived,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "Deliveries/", delivery))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                            if (result != null && result.Status == Const.SUCCESS_UPDATE_CODE)
                            {
                            }
                            else
                            {
                                return View(delivery);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
         

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .Include(d => d.DeliveryStaff)
                .Include(d => d.KoiOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(Guid id)
        {
            return _context.Deliveries.Any(e => e.Id == id);
        }
    }
}
