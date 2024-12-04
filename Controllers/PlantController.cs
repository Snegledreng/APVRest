using APVRest.Model;
using APVRest.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APVRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        public PlantService plantService { get; set; }= new ();

        // GET: api/<PlantController>
        [HttpGet("getall/{id}")]
        public IActionResult GetAllForUser(int id)
        {
            List<Plant> plants = plantService.GetAllPlants(id);
            if (plants is null)
                return NoContent();
            return Ok(plants);
        }

        // GET api/<PlantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Plant p1 = plantService.GetPlantById(id);
            if (p1 is null)
            {
                return NotFound();
            }
            return Ok(p1);

        }

        // POST api/<PlantController>
        [HttpPost]
        public IActionResult Post([FromBody] Plant p1)
        {
            try
            {
                plantService.CreatePlant(p1);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PlantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                plantService.DeletePlant(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PlantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Plant value)
        {
        }


    }
}
