using System.Threading.Tasks;
using Abp.Application.Services;
using Akaratak.Sessions.Dto;

namespace Akaratak.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
