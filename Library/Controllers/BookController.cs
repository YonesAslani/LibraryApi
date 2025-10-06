using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using LibraryServices.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/Book")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _BookServices;

        public BookController(IBookServices bookServices)
        {
            _BookServices = bookServices;
        }

        [HttpGet]
        public async Task<ActionResult<BookReturnModel>> GetBookAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result=await _BookServices.GetBookAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BookReturnModel>> AddBookAsync([FromBody] BookGetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _BookServices.AddBookAsync(model);
                    if (result == null)
                    {
                        return BadRequest();
                    }
                    return Ok(result);
                }
                catch
                {
                    return BadRequest(new { message = "لیست دسته ها نامعتبر است" });
                }
            }
            return BadRequest(ModelState.ErrorCount);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<BookReturnModel>> DeleteBookAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _BookServices.DeleteBookAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookReturnModel>> UpdateBookAsync(int id, [FromBody] UpdateBookModel? model)
        {
            
            if (id == 0 || model == null)
            {
                return NotFound(new { me = "sdfdf" });
            }
            var result = await _BookServices.UpdateBookAsync(id, model);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("GETAll")]
        public async Task<ActionResult<List<BookReturnModel>>> GetAllBooksAsyn()
        {
            var result = await _BookServices.GetAllBooksAsync();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
