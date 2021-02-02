using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.CandidatesDtos;
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
    public class CandidateController : ControllerBase
    {
        private CandidatesServices candidatesServices;
        public CandidateController()
        {
            candidatesServices = new CandidatesServices();
        }

        // GET: api/<CandidateController>
        [HttpGet]
        public List<FindCandidateDto> Get()
        {
            return this.candidatesServices.GetCandidates();
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public FindCandidateDto Get(int id)
        {
            return this.candidatesServices.GetCandidateById(id);
        }

        /*
        // GET api/<CandidateController>/5
        [Route("api/candidatesUser")]
        [HttpGet("{idUser}")]
        public List<FindCandidateDto> GetByIdUser(int idUser)
        {
            return this.candidatesServices.GetCandidateByIdUser(idUser);
        }
        */
        // POST api/<CandidateController>
        [HttpPost]
        public FindCandidateDto Post([FromBody] CreateCandidateDto cand)
        {
            return candidatesServices.PostCandidate(cand);
        }

        /*
        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return candidatesServices.DeleteCandidate(id);
        }
    }
}
