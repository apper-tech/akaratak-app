using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using akaratak_app.Data;
using akaratak_app.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace akaratak_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public TagController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET api/Tag
        [HttpGet(Name = "GetTags")]
        public async Task<IActionResult> GetTags()
        {
            var CategoriesFromRepo = await _repo.GetTags();
            if (CategoriesFromRepo != null)
                return Ok(_mapper.Map<ICollection<TagsToReturnDto>>(CategoriesFromRepo));
            else
                return BadRequest();
        }
    }
}