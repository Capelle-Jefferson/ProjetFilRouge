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
        public Dtos.RolesDtos.FindRolesDto Post([FromBody] Dtos.RolesDtos.CreatedRolesDto obj)
        {
            return rolesServices.PostRole(obj);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public Dtos.RolesDtos.FindRolesDto Put(int id, [FromBody] Dtos.RolesDtos.CreatedRolesDto obj)
        {
            return rolesServices.PutRole(id,obj);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return rolesServices.DeleteRole(id);
        }
    }
}
