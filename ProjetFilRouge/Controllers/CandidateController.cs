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
    
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private CandidatesServices candidatesServices;
        public CandidateController()
        {
            candidatesServices = new CandidatesServices();
        }

        // GET: api/<CandidateController>
        [HttpGet("api/[controller]")]
        public List<FindCandidateDto> Get()
        {
            return this.candidatesServices.GetCandidates();
        }

        // GET api/<CandidateController>/5
        [HttpGet("api /[controller]/{id}")]
        public FindCandidateDto Get(int id)
        {
            return this.candidatesServices.GetCandidateById(id);
        }

        // GET api/<CandidateController>/5
        [HttpGet("api/candidatesUser/{idUser}")]
        public List<FindCandidateDto> GetByIdUser(int idUser)
        {
            return this.candidatesServices.GetCandidateByIdUser(idUser);
        }

        // POST api/<CandidateController>
        [HttpPost("api/[controller]")]
        public FindCandidateDto Post([FromBody] CreateCandidateDto cand)
        {
            return candidatesServices.PostCandidate(cand);
        }


        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public FindCandidateDto Put(int id, [FromBody] CreateCandidateDto updatecandidate)
        {
            return candidatesServices.PutCandidate(id, updatecandidate);
        }


        // DELETE api/<CandidateController>/5
        [HttpDelete("api /[controller]{id}")]
        public int Delete(int id)
        {
            return candidatesServices.DeleteCandidate(id);
        }
    }
}
