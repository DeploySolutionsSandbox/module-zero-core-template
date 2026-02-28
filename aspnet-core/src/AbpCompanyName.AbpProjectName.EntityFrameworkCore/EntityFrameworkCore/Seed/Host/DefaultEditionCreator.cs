using Abp.Application.Editions;
using Abp.Application.Features;
using AbpCompanyName.AbpProjectName.Editions;
using Deploy.LaunchPad.Util.Elements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.Host;

public class DefaultEditionCreator
{
    private readonly AbpProjectNameDbContext _context;

    public DefaultEditionCreator(AbpProjectNameDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        CreateEditions();
    }

    private void CreateEditions()
    {
        var defaultEdition = _context.Editions.IgnoreQueryFilters().FirstOrDefault(e => e.Name.Full == EditionManager.DefaultEditionName);
        if (defaultEdition == null)
        {
            defaultEdition = new Edition { Id = Guid.NewGuid(), Name = new ElementName (EditionManager.DefaultEditionName), DisplayName = EditionManager.DefaultEditionName };
            _context.Editions.Add(defaultEdition);
            _context.SaveChanges();

            /* Add desired features to the standard edition, if wanted... */
        }
    }

    private void CreateFeatureIfNotExists(System.Guid editionId, string featureName, bool isEnabled)
    {
        if (_context.EditionFeatureSettings.IgnoreQueryFilters().Any(ef => ef.EditionId == editionId && ef.Name.Full == featureName))
        {
            return;
        }

        _context.EditionFeatureSettings.Add(new EditionFeatureSetting
        {
            Id= Guid.NewGuid(),
            Name = new ElementName( featureName),
            Value = isEnabled.ToString(),
            EditionId = editionId
        });
        _context.SaveChanges();
    }
}
