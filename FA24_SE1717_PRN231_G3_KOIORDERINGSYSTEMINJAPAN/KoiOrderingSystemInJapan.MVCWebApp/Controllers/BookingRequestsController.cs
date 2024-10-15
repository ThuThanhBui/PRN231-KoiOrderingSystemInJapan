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
    public class BookingRequestsController : Controller
    {
        private readonly HttpClient _http;

        public BookingRequestsController()
        {
        }

        // GET: BookingRequests
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "BookingRequests"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                        if (result != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<BookingRequest>>(result.Data.ToString());
                            return View(data);

                        }
                    }
                }
            }
            return View(new List<BookingRequest>());
        }

        // GET: BookingRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(Const.APIEndPoint + "BookingRequests/" + id))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
            //            if (result != null)
            //            {
            //                var data = JsonConvert.DeserializeObject<BookingRequest>(result.Data.ToString());
            //                return View(data);

            //            }
            //        }
            //    }
            //}
            //return View(new BookingRequest());
            return View(id);
        }

        // GET: BookingRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "BookingRequests/", bookingRequest))
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
                                return View(bookingRequest);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: BookingRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "BookingRequests/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);
                        if (result != null)
                        {
                            var data = JsonConvert.DeserializeObject<BookingRequest>(result.Data.ToString());

                            return View(data);
                        }
                    }
                }
            }
            return NotFound();
        }

        // POST: BookingRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PaymentAmount,PaymentDate,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] BookingRequest bookingRequest)
        {
            if (id != bookingRequest.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "BookingRequests/", bookingRequest))
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
                                return View(bookingRequest);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: BookingRequests/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookingRequest = await _context.BookingRequests
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bookingRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bookingRequest);
        //}

        // POST: BookingRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var bookingRequest = await _context.BookingRequests.FindAsync(id);
        //    if (bookingRequest != null)
        //    {
        //        _context.BookingRequests.Remove(bookingRequest);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookingRequestExists(Guid id)
        //{
        //    return _context.BookingRequests.Any(e => e.Id == id);
        //}
    }
}
