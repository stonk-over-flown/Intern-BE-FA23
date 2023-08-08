using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Service;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : ControllerBase
    {
        //AutoMapper explain
        //Dependency Injection explain
        private readonly IUserService _userService;
        public ActionController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpPost("getalluser")]
        public IActionResult GetAllUser()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("getallcard")]
        public IActionResult GetAllCard()
        {
            //finish getall
            return Ok();
        }


        //Tasks:
        //1: Tạo database code-first
        //2: Viết repository cho những entity có trong project
        //3: Viết service để thực hiện các chức năng CRUD cho các entity
    }
}
