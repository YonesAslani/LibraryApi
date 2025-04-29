using Microsoft.AspNetCore.Mvc;
using LibraryDbManager.DbModels;
using LibraryDbManager.Context;
using LibraryServices.IServices;
using LibraryDbManager.ReturnModels;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _AdminService;
        public AdminController(IAdminService AdminService)
        {
            _AdminService = AdminService;
        }

        [HttpGet]
        public async Task<ActionResult<AdminReturnModel>> GetAdminAsync(string UserName="",string Password="")
        {
            var result = await _AdminService.GetAdminAsync(UserName, Password);
            if (result == null)
            {
                return NotFound(new { message = "ادمین پیدا نشد" });
            }
            //return Ok(new AdminReturnModel()
            //{
            //    Id = result.Id,
            //    UserName=result.UserName,
            //    Password=result.PassWord,
            //    NationalCode=result.NationalCode,
            //    AdminType=result.AdminType.Name,
            //    FirstName=result.FirstName,
            //    LastName=result.LastName
            //});
            return new AdminReturnModel()
            {
                Id = result.Id,
                UserName = result.UserName,
                Password = result.PassWord,
                NationalCode = result.NationalCode,
                AdminType = result.AdminType.Name,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }

        [HttpPost]
        public async Task<ActionResult> AddAdminAsync([FromBody] Admin admin)
        {
            if (ModelState.IsValid)
            {
                var result = await _AdminService.AddAdminAsync(admin);
                if(result != null)
                {
                    return Ok(new {result=result});
                }
                return BadRequest(new { message = "ادمین اضافه نشد" });
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult<Admin>> UpdateAdminAsync(string username,string password,[FromBody] Admin admin)
        {
            if(ModelState.IsValid)
            {
                if (username==null || password==null)
                {
                    return BadRequest(new { message = "عدم تطابق اطلاعات" });
                }

                await _AdminService.UpdateAdminAsync(username,password,admin);
                return Ok(admin);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Admin>> DeleteAdminAsync(string Username,string Password)
        {
            if(Username==null || Password == null)
            {
                return BadRequest();
            }
            var result = await _AdminService.DeleteAdminAsync(Username, Password);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}
