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
   
    [ApiController]
    public class QuizzesController : ControllerBase
    {

        private QuizzesServices quizzesServices;
        public QuizzesController()
        {
            quizzesServices = new QuizzesServices();
        }

        // GET: api/<QuizzesController>
        [HttpGet("api/[controller]")]
        public List<FindQuizzDto> Get()
        {
            return quizzesServices.GetQuizzes();
        }

        // GET api/<QuizzesController>/5
        [HttpGet("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(quizzesServices.GetQuizzById(id));
            }
            catch
            {
                return NotFound();
            }    
        }

        [HttpGet("/api/UserQuizzes/{idCandidate}")]
        public IActionResult GetCandidateQuizzes(int idCandidate)
        {
            try
            {
                return Ok(quizzesServices.GetQuizzByCandidateId(idCandidate));
            }
            catch
            {
                return NotFound();
            }
        }
        
        [HttpGet("api/QuizzesInProgress/{id}")]
        public IActionResult GetInProgress(int id)
        {
            try
            {
                return Ok(quizzesServices.GetQuizzByIdInProgress(id));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<QuizzesController>
        [HttpPost("api/[controller]/{nbreQuestion}")]
        public FindQuizzDto Get(CreateQuizzDto createQuizzDto, int nbreQuestion)
        {
            return this.quizzesServices.GenerateQuizz(createQuizzDto, nbreQuestion);
        }

        // DELETE api/<QuizzesController>/5
        [HttpDelete("api/[controller]/{id}")]
        public int Delete(int id)
        {
            return this.quizzesServices.DeleteByIdQuizz(id);
        }

    }
}
