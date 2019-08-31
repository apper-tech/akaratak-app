using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Sessions.Dto;

namespace ApperTech.Akaratak.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
