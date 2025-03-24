using GadgetInspector.Server.Models.Technicians;

namespace GadgetInspector.Server.DataProviders.Technicians;

public interface ITechnicianDataProvider
{
    Task<List<TechnicianModel>> GetSuggestionsAsync(string searchText);
}
