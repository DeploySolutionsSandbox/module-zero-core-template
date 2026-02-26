using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.MultiTenancy.Dto;
using Deploy.LaunchPad.Core.Application.Services;

namespace AbpCompanyName.AbpProjectName.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, System.Guid, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

