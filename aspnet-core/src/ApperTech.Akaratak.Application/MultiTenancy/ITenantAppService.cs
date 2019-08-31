using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ApperTech.Akaratak.MultiTenancy.Dto;

namespace ApperTech.Akaratak.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

