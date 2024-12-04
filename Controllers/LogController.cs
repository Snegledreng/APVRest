using APVRest.IService;
using APVRest.Model;
using APVRest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static APVRest.Helpers.LogClusteredKey;

namespace APVRest.Controllers
{
    public class LogController : Controller
    {
        public LogService logService { get; set; } = new();
        // GET: api/<LogController>/getall/5
        [HttpGet("getall/{id}")]
        public IActionResult GetAllForUser(int id)
        {
            List<Log> logs = logService.GetAllLog(id);
            if (logs is null)
                return NoContent();
            return Ok(logs);
        }

        // GET: LogController/Details/5
        public IActionResult Get([FromBody] LogCK logCK)
        {
                Log l1 = logService.GetLogById(logCK.id, logCK.timestamp);
            if (l1 is null)
                return NoContent();
            return Ok(l1);

        }

        // GET: LogController/Create
        public ActionResult Create([FromBody] Log l1)
        {
            logService.CreateLog(l1);
            return Ok();
        }



        // GET: LogController/Delete/5
        public ActionResult Delete([FromBody] LogCK logCK)
        {
            try
            {
                logService.DeleteLog(logCK.id, logCK.timestamp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
