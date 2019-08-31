using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using ApperTech.Akaratak.Realestate.Dto;

namespace ApperTech.Akaratak.Realestate
{
    public interface IRealEstateAppService : IAsyncCrudAppService<PropertyDto,
        int,
        GetAllPropertyInput,
        CreatePropertyInput,
        UpdatePropertyInput>
    {
    }
}
