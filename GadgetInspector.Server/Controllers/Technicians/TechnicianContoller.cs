using GadgetInspector.Server.DataProviders.Technicians;
using GadgetInspector.Server.Models.Technicians;

namespace GadgetInspector.Server.Controllers.Technicians;

public class TechnicianController(
    ITechnicianDataProvider technicianDataProvider) : BaseController
{
    [HttpGet]
    [Route(NamedAction + "/{searchText}")]
    public async Task<List<TechnicianModel>> GetSuggestions(string searchText)
    {
        return await technicianDataProvider.GetSuggestionsAsync(searchText);
    }
   
}
