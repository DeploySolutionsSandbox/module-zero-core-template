using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.Sessions.Dto;
using Deploy.LaunchPad.Core.Application.Services;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
