using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private readonly HttpClient _http;

        public ServiceOrdersController()
        {
        }

        // GET: ServiceOrders
        public async Task<IActionResult> Index()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(Const.APIEndPoint + "ServiceOrders"))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            var result = JsonConvert.DeserializeObject<BusinessResult>(content);
            //            if (result != null)
            //            {
            //                var data = JsonConvert.DeserializeObject<List<ServiceOrder>>(result.Data.ToString());
            //                return View(data);

            //            }
            //        }
            //    }
            //}
            //return View(new List<ServiceOrder>());
            return View();
        }

        // GET: ServiceOrders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "ServiceOrders/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                        if (result != null && result.Data != null)
                        {
                            var data = JsonConvert.DeserializeObject<ServiceOrder>(result.Data.ToString());
                            return View(data);
                        }
                    }
                }
            }
            return View(new ServiceOrder());
        }


        //// GET: ServiceOrders/Create
        //public IActionResult Create()
        //{
        //    ViewData["CustomerServiceId"] = new SelectList(_context.CustomerServices, "Id", "Id");
        //    ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
        //    return View();
        //}

        //// POST: ServiceOrders/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CustomerServiceId,InvoiceId,Quantity,TotalPrice,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] ServiceOrder serviceOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        serviceOrder.Id = Guid.NewGuid();
        //        _context.Add(serviceOrder);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CustomerServiceId"] = new SelectList(_context.CustomerServices, "Id", "Id", serviceOrder.CustomerServiceId);
        //    ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", serviceOrder.InvoiceId);
        //    return View(serviceOrder);
        //}

        //// GET: ServiceOrders/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var serviceOrder = await _context.ServiceOrders.FindAsync(id);
        //    if (serviceOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CustomerServiceId"] = new SelectList(_context.CustomerServices, "Id", "Id", serviceOrder.CustomerServiceId);
        //    ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", serviceOrder.InvoiceId);
        //    return View(serviceOrder);
        //}

        //// POST: ServiceOrders/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,CustomerServiceId,InvoiceId,Quantity,TotalPrice,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] ServiceOrder serviceOrder)
        //{
        //    if (id != serviceOrder.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(serviceOrder);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ServiceOrderExists(serviceOrder.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CustomerServiceId"] = new SelectList(_context.CustomerServices, "Id", "Id", serviceOrder.CustomerServiceId);
        //    ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", serviceOrder.InvoiceId);
        //    return View(serviceOrder);
        //}

        //// GET: ServiceOrders/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var serviceOrder = await _context.ServiceOrders
        //        .Include(s => s.CustomerService)
        //        .Include(s => s.Invoice)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (serviceOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(serviceOrder);
        //}

        //// POST: ServiceOrders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var serviceOrder = await _context.ServiceOrders.FindAsync(id);
        //    if (serviceOrder != null)
        //    {
        //        _context.ServiceOrders.Remove(serviceOrder);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
