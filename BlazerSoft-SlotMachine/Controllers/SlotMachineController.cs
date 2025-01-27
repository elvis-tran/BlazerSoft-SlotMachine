using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazerSoft_SlotMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotMachineController : ControllerBase
    {
        //private readonly SlotMachineService
        private readonly ILogger<SlotMachineController> _logger;

        public SlotMachineController(ILogger<SlotMachineController> logger)
        {
            _logger = logger;
        }

        // GET: api/<SlotMachineController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SlotMachineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SlotMachineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SlotMachineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SlotMachineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
