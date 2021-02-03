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
    public class QuizzesController : ControllerBase
    {

        private QuizzesServices quizzesServices;
        public QuizzesController()
        {
            quizzesServices = new QuizzesServices();
        }

        // GET: api/<QuizzesController>
        [HttpGet]
        public List<FindQuizzDto> Get()
        {
            return quizzesServices.GetQuizzes();
        }

        // GET api/<QuizzesController>/5
        [HttpGet("{id}")]
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

        // POST api/<QuizzesController>
        [HttpGet("{nbreQuestion}/{idLevel}/{idCategory}")]
        public FindQuizzDto Get(int nbreQuestion, int idLevel, int idCategory)
        {
            return this.quizzesServices.GenerateQuizz(nbreQuestion, idLevel, idCategory);
        }

    }
}
