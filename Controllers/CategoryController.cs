using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using akaratak_app.Data;
using akaratak_app.Dtos;
using AutoMapper;

namespace akaratak_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public CategoryController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET api/Categories
        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var CategoriesFromRepo = await _repo.GetCategories();
            if (CategoriesFromRepo != null)
                return Ok(_mapper.Map<ICollection<CategoryToReturnDto>>(CategoriesFromRepo));
            else
                return BadRequest();
        }
    }
}