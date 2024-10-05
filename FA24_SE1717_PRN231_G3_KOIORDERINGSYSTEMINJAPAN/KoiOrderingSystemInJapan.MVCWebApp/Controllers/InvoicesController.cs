using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Service.Base;
using Newtonsoft.Json;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly HttpClient _http;

        public InvoicesController()
        {
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "Invoices"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                        if (result != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<Invoice>>(result.Data.ToString());
                            return View(data);

                        }
                    }
                }
            }
            return View(new List<Invoice>());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(Const.APIEndPoint + "Invoices/" + id))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
            //            if (result != null)
            //            {
            //                var data = JsonConvert.DeserializeObject<Invoice>(result.Data.ToString());
            //                return View(data);

            //            }
            //        }
            //    }
            //}
            //return View(new Invoice());
            return View(id);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "Invoices/", invoice))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                            if (result != null && result.Status == Const.SUCCESS_CREATE_CODE)
                            {
                            }
                            else
                            {
                                return View(invoice);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "Invoices/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                        if (result != null)
                        {
                            var data = JsonConvert.DeserializeObject<Invoice>(result.Data.ToString());

                            return View(data);
                        }
                    }
                }
            }
            return NotFound();
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PaymentAmount,PaymentDate,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "Invoices/", invoice))
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
                                return View(invoice);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoices/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoice = await _context.Invoices
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(invoice);
        //}

        // POST: Invoices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var invoice = await _context.Invoices.FindAsync(id);
        //    if (invoice != null)
        //    {
        //        _context.Invoices.Remove(invoice);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool InvoiceExists(Guid id)
        //{
        //    return _context.Invoices.Any(e => e.Id == id);
        //}
    }
}
