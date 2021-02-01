using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos;
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
    public class CategoriesController : ControllerBase
    {
        private CategoriesServices categoriesServices;
        public CategoriesController()
        {
            categoriesServices = new CategoriesServices();
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public List<FindCategoryDto> Get()
        {
            return categoriesServices.GetCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public FindCategoryDto Get(int id)
        {
            return categoriesServices.GetCategoryById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
