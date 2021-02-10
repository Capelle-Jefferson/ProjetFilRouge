using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos;
using ProjetFilRouge.Dtos.LevelDtos;
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
    public class LevelsController : ControllerBase
    {
        private LevelServices levelServices;
        public LevelsController()
        {
            levelServices = new LevelServices();
        }

        // GET: api/<LevelsController>
        [HttpGet]
        public List<FindLevelDto> Get()
        {
            return levelServices.GetLevels();
        }

        // GET api/<LevelsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try 
            {
                return Ok(levelServices.GetLevelById(id));
            }
            catch
            {
                return NotFound();
            }
            
        }

        // POST api/<LevelsController>
        [HttpPost]
        public FindLevelDto Post([FromBody] CreateLevelDto value)
        {
            return levelServices.PostLevel(value);
        }

        // PUT api/<LevelsController>/5
        [HttpPut("{id}")]
        public FindLevelDto Put(int id, [FromBody] CreateLevelDto lev)
        {
            return levelServices.PutLevel(id, lev);
        }

        // DELETE api/<LevelsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return levelServices.Delete(id);
        }
    }
}
