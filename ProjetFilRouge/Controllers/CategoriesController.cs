using HttpExceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ProjetFilRouge.Dtos;
using ProjetFilRouge.Dtos.CategoriesDtos;
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
        public CategoriesController(CategoriesServices categoriesServices)
        {
            this.categoriesServices = categoriesServices;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public List<FindCategoryDto> Get()
        {
            return categoriesServices.GetCategories();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(categoriesServices.GetCategoryById(id));
            }catch
            {
                return NotFound();
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public FindCategoryDto Post([FromBody] CreateCategoryDto cat)
        {
            return categoriesServices.PostCategory(cat);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public FindCategoryDto Put(int id, [FromBody] CreateCategoryDto cat)
        {
            return categoriesServices.PutCategory(id, cat);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return categoriesServices.Delete(id);
        }
    }
}
