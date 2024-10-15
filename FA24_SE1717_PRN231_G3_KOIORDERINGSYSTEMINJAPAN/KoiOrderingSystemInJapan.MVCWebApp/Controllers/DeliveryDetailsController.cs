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
using KoiOrderingSystemInJapan.Service.Base;
using Newtonsoft.Json;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class DeliveryDetailsController : Controller
    {
        private readonly KoiOrderingSystemInJapanContext _context;

        public DeliveryDetailsController()
        { 
        }
          

        // GET: DeliveryDetails
        public async Task<IActionResult> Index()
        {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(Const.APIEndPoint + "DeliveryDetails"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                            if (result != null && result.Data != null)
                            {
                                var data = JsonConvert.DeserializeObject<List<DeliveryDetail>>(result.Data.ToString());
                                return View(data);
                            }
                        }
                    }
                }
                return View(new List<Delivery>());
        }

        // GET: DeliveryDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "DeliveryDetails/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                        if (result != null)
                        {
                            var data = JsonConvert.DeserializeObject<DeliveryDetail>(result.Data.ToString());

                            return View(data);
                        }
                    }
                }
            }
            return NotFound();
        }

        // GET: DeliveryDetails/Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeliveryId,Name,Description,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                deliveryDetail.Id = Guid.NewGuid();
                _context.Add(deliveryDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Id", deliveryDetail.DeliveryId);
            return View(deliveryDetail);
        }

        // GET: DeliveryDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryDetail = await _context.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Id", deliveryDetail.DeliveryId);
            return View(deliveryDetail);
        }

        // POST: DeliveryDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DeliveryId,Name,Description,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] DeliveryDetail deliveryDetail)
        {
            if (id != deliveryDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryDetailExists(deliveryDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Id", deliveryDetail.DeliveryId);
            return View(deliveryDetail);
        }

        // GET: DeliveryDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryDetail = await _context.DeliveryDetails
                .Include(d => d.Delivery)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }

            return View(deliveryDetail);
        }

        // POST: DeliveryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deliveryDetail = await _context.DeliveryDetails.FindAsync(id);
            if (deliveryDetail != null)
            {
                _context.DeliveryDetails.Remove(deliveryDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryDetailExists(Guid id)
        {
            return _context.DeliveryDetails.Any(e => e.Id == id);
        }
    }
}
