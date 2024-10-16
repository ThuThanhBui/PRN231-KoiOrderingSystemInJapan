using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KoiOrderingSystemInJapan.MVCWebApp.Controllers
{
    public class KoiFishesController : Controller
    {
        private readonly KoiOrderingSystemInJapanContext _context;
        public KoiFishesController() { }

        // GET: KoiFishes
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "KoiFishes"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                        if (result != null && result.Data != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<KoiFish>>(result.Data.ToString());
                            return View(data);
                        }
                    }
                }
            }
            return View(new List<KoiFish>());
        }
        // GET: KoiFishes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Const.APIEndPoint + "KoiFishes/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<BusinessResult>(content);

                        if (result != null && result.Data != null)
                        {
                            var data = JsonConvert.DeserializeObject<List<KoiFish>>(result.Data.ToString());
                            return View(data);
                        }
                    }
                }
            }
            return View(new KoiFish());
        }
        // GET: KoiFishes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KoiFishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dob, CategoryId, Price, Description, Origin, Status, DateSold, Gender, CreatedBy, CreatedDate, UpdatedBy, UpdateedDate, IsDeleted")] KoiFish fish)
        {
            #region Save
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "KoiFishes/", fish))
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
                                return View(fish);
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Index");
            #endregion
        }
        // GET: Koifishes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            return View(id);
        }

        // POST: KOiFishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Dob, CategoryId, Price, Description, Origin, Status, DateSold, Gender, CreatedBy, CreatedDate, UpdatedBy, UpdateedDate, IsDeleted")] KoiFish fish)
        {
            if (id != fish.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(Const.APIEndPoint + "Fishs/", fish))
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
                                return View(fish);
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: KoiFishes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.KoiFishes
                .Include(d => d.Category)
                .Include(d => d.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fish = await _context.KoiFishes.FindAsync(id);
            if (fish != null)
            {
                _context.KoiFishes.Remove(fish);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(Guid id)
        {
            return _context.KoiFishes.Any(e => e.Id == id);
        }
    }
}
