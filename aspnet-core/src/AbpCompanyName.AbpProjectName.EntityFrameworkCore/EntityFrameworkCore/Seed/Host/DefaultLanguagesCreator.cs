using Abp.Localization;
using Abp.MultiTenancy;
using Deploy.LaunchPad.Core.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.Host;

public class DefaultLanguagesCreator
{
    public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

    private readonly AbpProjectNameDbContext _context;

    private static List<ApplicationLanguage> GetInitialLanguages()
    {
        var tenantId = AbpProjectNameConsts.MultiTenancyEnabled ? null : (System.Guid?)MultiTenancyConsts.DefaultTenantId;
        return new List<ApplicationLanguage>
        {
            new ApplicationLanguage(tenantId, "en", "English", "famfamfam-flags us"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "ar", "العربية", "famfamfam-flags sa"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "de", "German", "famfamfam-flags de"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "it", "Italiano", "famfamfam-flags it"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "fa", "فارسی", "famfamfam-flags ir"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "fr", "Français", "famfamfam-flags fr"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "pt-BR", "Português", "famfamfam-flags br"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "tr", "Türkçe", "famfamfam-flags tr"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "ru", "Русский", "famfamfam-flags ru"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "zh-Hans", "简体中文", "famfamfam-flags cn"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "es-MX", "Español México", "famfamfam-flags mx"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "nl", "Nederlands", "famfamfam-flags nl"){Id= Guid.NewGuid()},
            new ApplicationLanguage(tenantId, "ja", "日本語", "famfamfam-flags jp"){Id= Guid.NewGuid()}
        };
    }

    public DefaultLanguagesCreator(AbpProjectNameDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        CreateLanguages();
    }

    private void CreateLanguages()
    {
        foreach (var language in InitialLanguages)
        {
            AddLanguageIfNotExists(language);
        }
    }

    private void AddLanguageIfNotExists(ApplicationLanguage language)
    {
        if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
        {
            return;
        }

        _context.Languages.Add(language);
        _context.SaveChanges();
    }
}
