using Microsoft.AspNetCore.Mvc;
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
    public class QuestionsController : ControllerBase
    {
        QuestionsServices questionService;
        public QuestionsController () { this.questionService = new QuestionsServices(); } 
        // GET: api/<QuestionsController>
        [HttpGet]
        public List<Dtos.QuestionsDtos.FindQuestionsDto> Get()
        {
            return questionService.GetAllQuestions();
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public Dtos.QuestionsDtos.FindQuestionsDto Get(int id)
        {
            return questionService.GetQuestions(id);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
