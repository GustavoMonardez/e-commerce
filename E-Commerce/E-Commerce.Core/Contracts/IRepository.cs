using System.Linq;
using E_Commerce.Core.Models;

namespace E_Commerce.Core.Contracts {
    public interface IRepository<T> where T : BaseEntity {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T item);
        void Update(T item);
    }
}