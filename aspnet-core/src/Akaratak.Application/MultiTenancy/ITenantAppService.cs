using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Akaratak.MultiTenancy.Dto;

namespace Akaratak.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

