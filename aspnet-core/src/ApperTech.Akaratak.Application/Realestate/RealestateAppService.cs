using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ApperTech.Akaratak.Realestate.Dto;

namespace ApperTech.Akaratak.Realestate
{
    public class RealEstateAppService :
        AsyncCrudAppService<Property, PropertyDto, int, GetAllPropertyInput, CreatePropertyInput, UpdatePropertyInput>,
        IRealEstateAppService
    {
        public RealEstateAppService(IRepository<Property, int> repository) : base(repository)
        {
        }
    }
}
