using GadgetInspector.Server.Models.GadgetTypes;
using GadgetInspector.Services.GadgetTypes;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Server.DataProviders.GadgetTypes;

public class GadgetTypeDataProvider(
    IGadgetTypeService gadgetTypeService) : IGadgetTypeDataProvider
{
    public async Task<List<GadgetTypeModel>> GetGadgetTypesAsync()
    {
        //TODO:This call should be cached
        // And this could be an AutoMapper instead of a manual mapping
        return await gadgetTypeService.GetEntities(EntityType.Untracked)
            .OrderBy(x => x.Name).Select(x => new GadgetTypeModel
            {
                Id = x.Id,
                Name = x.Name,
                InspectionIntervalDays = x.InspectionIntervalDays
            }).ToListAsync();
    }
}
