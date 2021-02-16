using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Dtos.QuizzQDTO;
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
    public class QuizzQuestionController : ControllerBase
    {
        QuizzQuestionService quizzquestionService;
        public QuizzQuestionController() { this.quizzquestionService = new QuizzQuestionService(); }

        // GET: api/<QuizzQuestionController>
        [HttpGet]
        public List<Dtos.QuizzQDTO.FindQuizzQDto> Get()
        {
            return quizzquestionService.GettAllQuizzQ();
        }

        // GET api/<QuizzQuestionController>/5
        [HttpGet("{idQuizz}")]
        public IActionResult Get(int idQuizz)
        {
            try
            {
                return Ok(quizzquestionService.GetQuizzQ(idQuizz));
            }
            catch
            {
                return NotFound();
            }
        }

        /*
        // POST api/<QuizzQuestionController>
        [HttpPost]
        public Dtos.QuizzQDTO.FindQuizzQDto Post([FromBody] Dtos.QuizzQDTO.CreateQuizzQDto obj)
        {
            return quizzquestionService.PostQuizzQ(obj);
        }
        */

        [HttpPut]
        public FindQuizzQDto Put(int idQuizz, int idQuestion, [FromBody] string answer)
        {
            return this.quizzquestionService.AddAnswerCandidate(idQuizz, idQuestion, answer);
        }
    }

}

