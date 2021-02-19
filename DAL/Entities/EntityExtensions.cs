using System;

namespace DAL.Entities
{
    public static class EntityExtensions
    {
        public static T Stamp<T>(this T entity, Guid userId, bool isInit = true) where T : Entity
        {
            if (isInit)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.CreatedBy = userId;
            }
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedBy = userId;
            return entity;
        }
    }
}
