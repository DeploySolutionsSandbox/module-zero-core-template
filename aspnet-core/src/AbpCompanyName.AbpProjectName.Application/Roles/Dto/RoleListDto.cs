using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Deploy.LaunchPad.Core.Application.Services.Dto;
using Deploy.LaunchPad.Core.Metadata;
using System;

namespace AbpCompanyName.AbpProjectName.Roles.Dto;

public class RoleListDto : EntityDto, IMustHaveCreationTime
{
    public string Name { get; set; }

    public string DisplayName { get; set; }

    public bool IsStatic { get; set; }

    public bool IsDefault { get; set; }

    public DateTime CreationTime { get; set; }
}
