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
    public class CityController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public CityController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET api/Category
        [HttpGet("{code}")]
        public async Task<IActionResult> GetCities(string code)
        {
            var CitiesFromRepo = await _repo.GetCities(code);
            if (CitiesFromRepo != null)
                return Ok(_mapper.Map<ICollection<CityToReturnDto>>(CitiesFromRepo));
            else
                return BadRequest();
        }
    }
}