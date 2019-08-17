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
    public class CurrencyController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        public CurrencyController(IPropertyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        // GET api/Category
        [HttpGet(Name = "GetCurrencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            var CurrenciesFromRepo = await _repo.GetCurrencies();
            if (CurrenciesFromRepo != null)
                return Ok(_mapper.Map<ICollection<CurrencyToReturnDto>>(CurrenciesFromRepo));
            else
                return BadRequest();
        }
    }
}