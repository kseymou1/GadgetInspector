using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Services.Gadgets.Support;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Services.Gadgets;

public class GadgetsGridService(
    MainDbContext mainDbContext
    ) : IGadgetsGridService
{
    public async Task<IList<GadgetsGridItem>> GetGridItemsAsync(GadgetsGridRequest request)
    {
        string sql = $"EXEC dbo.Gadgets_GetGridItems @gadgetTypeId = @gadgetTypeId";

        SqlParameter[] sqlParams = [
            new("@gadgetTypeId", request.GadgetTypeId is null ? DBNull.Value : request.GadgetTypeId)
        ];

        return await mainDbContext.GadgetsGridItems.FromSqlRaw(sql, sqlParams).ToListAsync();
    }
}