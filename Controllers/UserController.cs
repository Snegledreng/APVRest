using APVRest.IService;
using APVRest.Model;
using APVRest.Service;
using Microsoft.AspNetCore.Mvc;

namespace APVRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        public UserService userService { get; set; } = new();

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
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                userService.CreateUser(value);
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
        public IActionResult Put(int id, [FromBody] User value)
        {
            try
            {
                userService.UpdateUser(value, id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
