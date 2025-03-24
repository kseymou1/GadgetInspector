using GadgetInspector.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Services;

public class BaseEntityService<T>(IServiceCommon serviceCommon) : BaseService(serviceCommon), IEntityService<T> where T : class, IBaseEntity
{
    #region IEntityService<T> Properties
    public DbSet<T> Entities => ServiceCommon.MainDbContext.Set<T>();
    public IQueryable<T> EntitiesNoTracking => Entities.AsNoTracking();
    public IQueryable<T> EntitiesNoTrackingWithIdentityResolution => Entities.AsNoTrackingWithIdentityResolution();
    #endregion

    #region IEntityService Methods
    public async ValueTask<T?> FindByIdAsync(int id)
    {
        //MS says to await EF Core Tasks immediately.
        //https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues
        return await Entities.FindAsync(id);
    }

    public IQueryable<T> GetById(int id, EntityType entityType)
    {
        return GetEntities(entityType).Where(x => x.Id == id);
    }

    //https://learn.microsoft.com/en-US/dotnet/csharp/language-reference/operators/switch-expression
    public IQueryable<T> GetEntities(EntityType entityType) => entityType switch
    {
        EntityType.Tracked => Entities,
        EntityType.Untracked => EntitiesNoTracking,
        EntityType.UntrackedWithIdentityResolution => EntitiesNoTrackingWithIdentityResolution,
        _ => throw new ArgumentOutOfRangeException(nameof(entityType), $"Unexpected value: {entityType}")
    };

    public Task InsertAsync(T entity, bool saveChanges = true)
    {
        this.Entities.Add(entity);
        return GetTask(saveChanges);
    }

    public Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        this.Entities.AddRange(entities);
        return GetTask(saveChanges);
    }

    public Task UpdateAsync(T entity, bool saveChanges = true)
    {
        this.Entities.Update(entity);
        return GetTask(saveChanges);
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        this.Entities.UpdateRange(entities);
        return GetTask(saveChanges);
    }

    public Task DeleteAsync(T entity, bool saveChanges = true)
    {
        this.Entities.Remove(entity);
        return GetTask(saveChanges);
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
    {
        this.Entities.RemoveRange(entities);
        return GetTask(saveChanges);
    }

    public async Task SaveChangesAsync()
    {
        //MS says to await EF Core Tasks immediately.
        //https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#avoiding-dbcontext-threading-issues

        //Returns int number of entities written to database.
        //Probably not that useful for us
        _ = await ServiceCommon.MainDbContext.SaveChangesAsync();
    }
    #endregion

    #region Support
    private Task GetTask(bool saveChanges)
    {
        return saveChanges ? SaveChangesAsync() : Task.CompletedTask;
    }
    #endregion
}
