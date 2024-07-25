using ECommerceAPI.Models;
using ECommerceAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAllCategorys()
        {
            var categorys = _categoryRepository.GetAllCategorys();
            return Ok(categorys);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        [Route("/api/Category/create")]//https://localhost:7268/api/Category/create
        public IActionResult AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || id != category.Id)
            {
                return BadRequest();
            }
            var existingCategory = _categoryRepository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryRepository.UpdateCategory(category);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = _categoryRepository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}
