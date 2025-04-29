using LibraryDbManager.DbModels;
using LibraryServices.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _CategoryService;

        public CategoryController(ICategoryServices categoryservices)
        {
            _CategoryService = categoryservices;
        }

        [HttpGet]
        public async Task<ActionResult<Category>> GetCategoryAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _CategoryService.GetCategoryAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategoryAsync(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return BadRequest();
            }
            return await _CategoryService.AddCategoryAsync(name);
        }

        [HttpGet("Delete/{id}")]
        public async Task<ActionResult<Category>> DeleteCategoryAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _CategoryService.DeleteCategoryAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategoryAsync(int id, [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                if (id == category.Id)
                {
                    var result = await _CategoryService.UpdateCategoryAsync(category);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return result;
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
        {
            var result=await _CategoryService.GetAllCategoriesAsync();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
