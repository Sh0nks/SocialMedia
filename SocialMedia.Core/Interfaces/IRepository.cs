using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T model);
        Task Update(T model);
        Task Delete(int d);
    }
}