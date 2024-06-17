
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.Dtos;
using PersonService.Application.Interfaces;
using System.Text.Json;

namespace PersonService.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {

        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpPost]
        public ActionResult RowTheDice([FromBody] RowTheDiceInput input)
        {
            var result = _personManager.RowTheDice(input).Result;

            return Ok(result);
        }

        [HttpGet]
        public ActionResult TestPerson()
        {
            var result = _personManager.TestPerson().Result;

            return Ok(result);
        }
    }
}
