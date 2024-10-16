using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService ??= new CategoryService();
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<IBusinessResult> GetCategory()
        {
            return await _categoryService.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetCategory(Guid id)
        {
            var cate = await _categoryService.GetById(id);

            return cate;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutCategory(Category cate)
        {

            return await _categoryService.Save(cate);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostCategory(Category cate)
        {
            return await _categoryService.Save(cate);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteCategory(Guid id)
        {
            return await _categoryService.DeleteById(id);
        }
    }
}
