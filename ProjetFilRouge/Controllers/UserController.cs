using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.CandidatesDtos;
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
    public class UserController : ControllerBase
    {
        private UsersServices UsersServices;
        
        public UserController()
        {
            UsersServices = new UsersServices();
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<FindUserDto> Get()
        {
            return this.UsersServices.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public FindUserDto Get(int id)
        {
            return this.UsersServices.GetUserById(id);
        }

        // GET api/<CandidateController>/5
        [HttpGet("/api/User/Role/{idRole}")]
        public List<FindUserDto> GetByIdRole(int idRole)
        {
            return this.UsersServices.GetUserByIdRoles(idRole);
        }

        // POST api/<UserController>
        [HttpPost]
        public FindUserDto Post([FromBody] CreateUserDto obj)
        {
            return UsersServices.PostUser(obj);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public FindUserDto Put(int id, [FromBody] CreateUserDto user)
        {
            return UsersServices.PutUser(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return UsersServices.DeleteUser(id);
        }
    }
}
