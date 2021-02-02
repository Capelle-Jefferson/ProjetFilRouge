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
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(questionService.GetQuestions(id));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public Dtos.QuestionsDtos.FindQuestionsDto Post([FromBody] Dtos.QuestionsDtos.CreatedQuestionDTO obj)
        {
            return questionService.PostQuestion(obj);
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public Dtos.QuestionsDtos.FindQuestionsDto Put(int id, [FromBody] Dtos.QuestionsDtos.CreatedQuestionDTO obj)
        {
            return questionService.PutQuestion(id, obj);
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return questionService.DeleteQuestion(id);
        }
    }
}
