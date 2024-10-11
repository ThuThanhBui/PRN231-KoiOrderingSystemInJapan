using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class DeliveriesController : Controller
    {
        private readonly KoiOrderingSystemInJapanContext _context;

        public DeliveriesController(KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
            var koiOrderingSystemInJapanContext = _context.Deliveries.Include(d => d.DeliveryStaff).Include(d => d.KoiOrder);
            return View(await koiOrderingSystemInJapanContext.ToListAsync());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            ViewData["DeliveryStaffId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["KoiOrderId"] = new SelectList(_context.KoiOrders, "Id", "Id");
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KoiOrderId,DeliveryStaffId,Code,Name,Phone,Address,TotalAmount,PaymentReceived,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsDeleted")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                delivery.Id = Guid.NewGuid();
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryStaffId"] = new SelectList(_context.Users, "Id", "Id", delivery.DeliveryStaffId);
            ViewData["KoiOrderId"] = new SelectList(_context.KoiOrders, "Id", "Id", delivery.KoiOrderId);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            ViewData["DeliveryStaffId"] = new SelectList(_context.Users, "Id", "Id", delivery.DeliveryStaffId);
            ViewData["KoiOrderId"] = new SelectList(_context.KoiOrders, "Id", "Id", delivery.KoiOrderId);
            return View(delivery);
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
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.Id))
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
            ViewData["DeliveryStaffId"] = new SelectList(_context.Users, "Id", "Id", delivery.DeliveryStaffId);
            ViewData["KoiOrderId"] = new SelectList(_context.KoiOrders, "Id", "Id", delivery.KoiOrderId);
            return View(delivery);
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
