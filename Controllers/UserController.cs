using APVRest.IService;
using APVRest.Model;
using APVRest.Service;
using Microsoft.AspNetCore.Mvc;
using static APVRest.Model.UserModelDTO;

namespace APVRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        public UserService userService { get; set; }

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(userService.GetUserById(id));
            }
            catch (ArgumentException ex) 
            {
                return NotFound(ex);
            }
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO value)
        {
            try
            {
                userService.CreateUser(UserDTO2User(value));
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO value)
        {
            try
            {
                userService.UpdateUser(UserDTO2User(value), id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
