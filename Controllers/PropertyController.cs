using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using akaratak_app.Data;
using akaratak_app.Dtos;
using akaratak_app.Helpers;
using AutoMapper;

namespace akaratak_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public PropertyController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetProperties([FromBody] PropertyParams propParam)
        {
            var props = await _repo.GetProperties(propParam);
            var propsToReturn = _mapper.Map<IEnumerable<PropertyToReturnDto>>(props);
            Response.AddPagination(props.CurrentPage, props.PageSize, props.TotalCount, props.TotalCount);
            return Ok(propsToReturn);
        }
        [HttpGet("{id}", Name = "GetProperty")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var propFromRepo = await _repo.GetProperty(id);
            if (propFromRepo != null)
            {
                return Ok(_mapper.Map<PagedList<PropertyToReturnDto>>(propFromRepo));
            }
            return BadRequest();

        }
    }
}