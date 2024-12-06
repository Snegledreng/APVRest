using APVRest.IService;
using APVRest.Model;
using APVRest.Service;
using Microsoft.AspNetCore.Mvc;

namespace APVRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        public UserService userService { get; set; } = new();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User u1 = userService.GetUserById(id);
            if (u1 is null)
            {
                return NotFound();
            }
            return Ok(u1);

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
            catch (ArgumentException ex)
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

        [HttpGet("{uName}{password}")]
        public IActionResult Get(string uName, string password)
        {
            try
            {
                int UID = userService.LogIn(uName, password);
                return Ok(UID);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
