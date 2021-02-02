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
    public class RolesController : ControllerBase
    {
        public RolesServices rolesServices; 

        public RolesController()
        {
            this.rolesServices = new RolesServices();
        }
        // GET: api/<RolesController>
        [HttpGet]
        public List<Dtos.RolesDtos.FindRolesDto> Get()
        {
            return rolesServices.GetAllRoles();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public Dtos.RolesDtos.FindRolesDto Get(int id)
        {
            return rolesServices.GetRoles(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
