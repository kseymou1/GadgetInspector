using GadgetInspector.Core.Domain.Technicians;
using GadgetInspector.Server.Models.Technicians;
using GadgetInspector.Services.Technicians;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Server.DataProviders.Technicians;

public class TechnicianDataProvider(
    ITechnicianService technicianService) : ITechnicianDataProvider
{
    public async Task<List<TechnicianModel>> GetSuggestionsAsync(string searchText)
    {
        List<Technician> result = await GetTechniciansBySearchTextAsync(searchText);
        return result.Select(x => new TechnicianModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

    #region GetSuggestionsAsync Support
    private async Task<List<Technician>> GetTechniciansBySearchTextAsync(string searchText)
    {
        int takeAmount = 10;

        IQueryable<Technician> startsWithResults = technicianService.EntitiesNoTracking
           .Where(x => x.Name.StartsWith(searchText))
           .OrderBy(x => x.Name)
           .Take(takeAmount);

        IQueryable<Technician> containsResults = technicianService.EntitiesNoTracking
            .Where(x => x.Name.Contains(searchText))
            .OrderBy(x => x.Name)
            .Take(takeAmount);

        return await startsWithResults.Union(containsResults).ToListAsync();
    }
    #endregion
}
