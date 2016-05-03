using System.Collections.Generic;

namespace Pantry.Models.Repositories {
    public interface IRepository<T> where T : IEntity {
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        T GetById(int entityId);
        T GetByName(string name);
        IEnumerable<T> Get();
    }
}
