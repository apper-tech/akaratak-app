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
    public class CountryController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public CountryController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET api/Category
        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var CountriesFromRepo = await _repo.GetCountries();
            if (CountriesFromRepo != null)
                return Ok(_mapper.Map<ICollection<CountryToReturnDto>>(CountriesFromRepo));
            else
                return BadRequest();
        }
    }
}