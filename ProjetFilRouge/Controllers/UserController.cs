using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos.CandidatesDtos;
using ProjetFilRouge.Dtos.EmailDtos;
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

        public UserController(UsersServices usersServices)
        {
            this.UsersServices = usersServices;   
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


        [HttpPut("/api/Authentification")]
        public IActionResult Put(AuthUserDto userDto)
        {
            FindUserDto user = this.UsersServices.IsAvailableUser(userDto.Username, userDto.Password);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

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
        // POST api/<UserController>
        [HttpPost("/api/Recruteur")]
        public FindUserDto Post([FromBody] CreateRecruteurDto obj)
        {
            return UsersServices.PostRecruteur(obj);
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
