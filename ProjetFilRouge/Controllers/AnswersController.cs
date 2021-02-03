using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetFilRouge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private AnswerServices AnswerServices;
        public AnswersController()
        {
            AnswerServices = new AnswerServices();
        }

        // GET: api/<AnswersController>
        [HttpGet]
        public List<FindAnswerDto> Get()
        {
            return AnswerServices.GetAnswers();           
        }

        // GET api/<AnswersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(AnswerServices.GetAnswerById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<AnswersController>
        [HttpPost]
        public FindAnswerDto Post([FromBody] CreateAnswerDto value)
        {
            return AnswerServices.PostAnswer(value);
        }

        // PUT api/<AnswersController>/5
        [HttpPut("{id}")]
        public FindAnswerDto Put(int id, [FromBody] CreateAnswerDto value)
        {
            return AnswerServices.PutAnswer(id, value);
        }

        // DELETE api/<AnswersController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return AnswerServices.Delete(id);
        }
    }
}
