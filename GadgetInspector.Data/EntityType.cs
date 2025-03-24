namespace GadgetInspector.Data;

//See: https://learn.microsoft.com/en-us/ef/core/querying/tracking
//Tracked - EF tracks the entities and is affected by DbContext.SaveChanges().
//      In service methods, assume entities are tracked unless otherwise noted.
//
//Untracked - Entities are not tracked - changes are not affected by SaveChanges().
//      If the entities with the same Id are loaded multiple times, you will have multiple instances.
//      Typically use Untracked for one-time queries of data that's presentation-only.
//
//UntrackedWithIdentityResolution - Same as Untracked, except that EF will ensure a single instance
//      of an entity per Id.  
//      Typically if this is a factor, carefully consider whether tracked entities would be better.
public enum EntityType
{
    Tracked,
    Untracked,
    UntrackedWithIdentityResolution
}
