using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using Deploy.LaunchPad.Core.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.Host;

public class DefaultSettingsCreator
{
    private readonly AbpProjectNameDbContext _context;

    public DefaultSettingsCreator(AbpProjectNameDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        System.Guid? tenantId = null;

        if (AbpProjectNameConsts.MultiTenancyEnabled == false)
        {
            tenantId = MultiTenancyConsts.DefaultTenantId;
        }

        // Emailing
        AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com", tenantId);
        AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer", tenantId);

        // Languages
        AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en", tenantId);
    }

    private void AddSettingIfNotExists(string name, string value, System.Guid? tenantId = null)
    {
        if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name.Full == name && s.TenantId == tenantId && s.UserId == null))
        {
            return;
        }

        _context.Settings.Add(new Setting(tenantId, null, name, value)
        {
            Id = Guid.NewGuid(),
        });
        _context.SaveChanges();
    }
}
