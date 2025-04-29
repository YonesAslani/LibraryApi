using LibraryDbManager.DbModels;
using LibraryDbManager.ReturnModels;
using LibraryServices.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/Costumer")]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerServices _CostumerServices;

        public CostumerController(ICostumerServices costumerServices)
        {
            _CostumerServices = costumerServices;
        }

        [HttpGet]
        public async Task<ActionResult<Costumer>> GetCostumerAsync(string username,string password)
        {
            var result= await _CostumerServices.GetCostumerAsync(username,password);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Costumer>> AddCostumerAsync([FromBody] Costumer model)
        {
            if(ModelState.IsValid)
            {
                var result=await _CostumerServices.AddCostumerAsync(model);
                if (result == null)
                {
                    return BadRequest();
                }
                //return CreatedAtAction("GetCostumerAsync", new { id = model.Id }, model);
                return result;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<ActionResult<Costumer>> DeleteCostumerAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var result = await _CostumerServices.DeleteCostumerAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Costumer>> UpdateCostumerAsync(int id,[FromBody] Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                if (costumer == null || id <= 0 || costumer.Id <= 0 || (id != costumer.Id) || costumer.Id == null)
                {
                    return BadRequest();
                }
                var result = await _CostumerServices.UpdateCostumerAsync(costumer);
                if (result == null)
                {
                    return BadRequest(new {message="لطفا مشتری را وارد کنید"});
                }
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Costumer>>> GetAllCostumersAsyn()
        {
            var result = await _CostumerServices.GetAllCotumersAsyn();
            if (result == null) return null;
            return Ok(result);
        }
    }
}
