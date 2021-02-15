using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Models;
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

        // GET api/<QuestionsController>/
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

        [HttpGet("{idLevel}/{idCategory}/{nombreQuestion}")]

        public List<Question> GetQuestions(int idLevel,int idCategory,int nombreQuestion)
        {
            return questionService.GetQuestionQuizz(idLevel, idCategory, nombreQuestion);
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public Dtos.QuestionsDtos.FindQuestionsDto Post([FromBody] Dtos.QuestionsDtos.CreatedQuestionDTO obj)
        {
            return questionService.PostQuestion(obj);
        }

        // PUT api/<QuestionsController>/
        [HttpPut("{id}")]
        public Dtos.QuestionsDtos.FindQuestionsDto Put(int id, [FromBody] Dtos.QuestionsDtos.CreatedQuestionDTO obj)
        {
            return questionService.PutQuestion(id, obj);
        }

        // DELETE api/<QuestionsController>/
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return questionService.DeleteQuestion(id);
        }
    }
}
