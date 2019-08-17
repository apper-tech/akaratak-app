using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using akaratak_app.Data;
using akaratak_app.Dtos;
using akaratak_app.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using akaratak_app.Models;

namespace akaratak_app.Controllers
{
    [Route("api/[controller]")]
    [Consumes("multipart/form-data", "application/json")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        private readonly PhotosController photoManager;
        public PropertyController(IPropertyRepository repo, IMapper mapper, PhotosController photoManager)
        {
            this.photoManager = photoManager;
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetProperties([FromBody] PropertyToListDto propParam)
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
        [HttpPost(Name = "AddProperty")]
        [Route("[action]")]
        public async Task<IActionResult> AddProperty([FromBody] PropertyToInsertDto propertyToInsert)
        {
            await Task.Run(() => { });
            var property = _repo.CastPropertyFromInsert(propertyToInsert);

            //authenticate with identity

            _repo.Add<Property>(property);
            if (await _repo.SaveAll())
                return CreatedAtRoute(string.Format(@"GetProperty/{0}", property.ID), property);
            return BadRequest("Could Not Insert Property");
        }
        [HttpPost(Name = "Test"), DisableRequestSizeLimit]
        [Route("[action]")]
        public async Task<IActionResult> Test()
        {
            await Task.Run(() => { });
            foreach (var item in Request.Form.Files)
            {
                var s = item.Name.ToString();
            }
            return Ok(Request.Form.Files);
        }
    }
}