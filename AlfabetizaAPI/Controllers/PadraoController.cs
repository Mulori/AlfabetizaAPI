using AlfabetizaAPI.Models.Entities;
using AlfabetizaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PadraoController : ControllerBase
    {
        public ICalculate _Calculate;

        Padrao _padrao = new Padrao();

        public PadraoController(ICalculate calculate)
        {
            _padrao.application_name = "Alfabetiza API";
            _padrao.developer_name = "Murilo Henrique Garcia Rodrigues";
            _padrao.date_time_now = DateTime.Now;

            _Calculate = calculate;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_padrao);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 100)
                return BadRequest("Id is lower 100");

            var obj = new {
                Created_in = Convert.ToDateTime("2022-01-20 22:38"),
                City_Of_Creation = "Bebedouro",
                State_Of_Creation = "São Paulo",
                Country_Of_Creation = "Brazil",
                Developer_Name = "Murilo Henrique Garcia Rodrigues",
                Developer_Age = "21",
                Developer_Nationality = "Brazilian"
            };

            return Ok(obj);
        }

        [HttpGet("sum/{number_one}/{number_two}")]
        public IActionResult GetSum(int number_one, int number_two)
        {
            return Ok(_Calculate.Sum(number_one, number_two));
        }
    }
}
