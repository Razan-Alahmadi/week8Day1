using Microsoft.AspNetCore.Mvc;
using Week8Day1Task.Repository;
using Week8Day1Task.Models;

namespace Week8Day1Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

     
        private readonly IUserRepository userService;
        public UserController(IUserRepository _userService)
        {
            userService = _userService;
        }

        //----------------------------------------------

        [HttpGet("userlist")]
        public IEnumerable<User> UserList()
        {
            var userList = userService.GetAll();
            return userList;
        }


        [HttpGet("getUserbyId")]
        public User GetUserById(int Id)
        {
            return userService.GetById(Id);
        }




        [HttpPost("addUser")]
        public User AddUser(User user)
        {
            return userService.Add(user);
        }




        [HttpPut("updatUser")]
        public User UpdateUser(User user)
        {
            return userService.Update(user);
        }


        [HttpDelete("deleteUser")]
        public bool DeleteUser(int Id)
        {
            return userService.Delete(Id);
        }


    }
}
