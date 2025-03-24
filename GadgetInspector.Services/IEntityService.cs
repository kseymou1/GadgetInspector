using GadgetInspector.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Services;

public interface IEntityService<T> : IBaseService where T: class, IBaseEntity
{
    /// <summary>
    /// Gets tracked entities - use when you want to save entities.
    /// </summary>
    DbSet<T> Entities { get; }
    
    /// <summary>
    /// Gets untracked entities - cannot save via the context's SaveChanges method.
    /// Use when you do not expect the a non-tracked entity with the same id to appear more than once.
    /// If such entities are requested, there will be multiple instances of the entities with the same id.
    /// </summary>
    IQueryable<T> EntitiesNoTracking { get; }

    /// <summary>
    /// Gets untracked entities - cannot save via the context's SaveChanges method.
    /// Use when you expect entities with the same id to appear more than once.
    /// Although the entities will still not be tracked for saving purposes, entities with the same
    /// id will be the same reference.
    /// </summary>
    IQueryable<T> EntitiesNoTrackingWithIdentityResolution { get; }

    /// <summary>
    /// Convenience method to get tracked, untracked, or untracked (with identity resolution) entites.
    /// </summary>
    /// <param name="entityType">Entity type that specifies whether to use track, untracked, or untracked (with identity resolution) entities.</param>
    IQueryable<T> GetEntities(EntityType entityType);

    /// <summary>
    /// Gets a tracked entity with the given id.
    /// Mimics behavior of DbSet FindAsync method.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<T?> FindByIdAsync(int id);
        
    /// <summary>
    /// Gets a queryable for the supplied id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entityType"></param>
    /// <returns></returns>
    /// to allow for Includes.</remarks>
    IQueryable<T> GetById(int id, EntityType entityType);

    /// <summary>
    /// Inserts a single entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    /// <remarks>Only has meaning with tracked entities.</remarks>
    Task InsertAsync(T entity, bool saveChanges = true);

    /// <summary>
    /// Inserts multiple entities.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    /// <remarks>Only has meaning with tracked entities.</remarks>
    Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

    /// <summary>
    /// Updates a single entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    /// <remarks>Only has meaning with tracked entities.</remarks>
    Task UpdateAsync(T entity, bool saveChanges = true);

    /// <summary>
    /// Updates multiple entities
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

    /// <summary>
    /// Performs a hard delete of an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    /// <remarks>Only has meaning with tracked entities.</remarks>
    Task DeleteAsync(T entity, bool saveChanges = true);

    /// <summary>
    /// Performs hard deletes of multiple entities
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="saveChanges">
    /// True: Save immediately.
    /// False: Performs the operation but does not commit it to the backing store until 
    /// another operation is performed with saveChanges is true or SaveChangesAsync is manually called.
    /// </param>
    /// <returns></returns>
    /// <remarks>Only has meaning with tracked entities.</remarks>
    Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

    /// <summary>
    /// Saves any uncommitted changes to the backing store.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}
