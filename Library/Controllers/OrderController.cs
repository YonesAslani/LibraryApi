using LibraryDbManager.ReturnModels;
using LibraryServices.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _OrderServices;
        public OrderController(IOrderServices orderServices)
        {
            _OrderServices = orderServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrderAsync(int orderid)
        {
            if(orderid <= 0)
            {
                return BadRequest();
            }
            else
            {
                var result=await _OrderServices.GetOrderAsync(orderid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] OrderGetModel model)
        {
            if (model==null)
            {
                return BadRequest();
            }
            var result=await _OrderServices.AddOrderAsync(model);
            return Ok(result);
        }
    }
}
