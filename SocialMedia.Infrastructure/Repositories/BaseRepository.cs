using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastruncture.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRepository<T>: IRepository<T> where T: BaseEntity
    {
        private readonly SocialMediaContext _context;
        private DbSet<T> _entities;

        public BaseRepository(SocialMediaContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Create(T model)
        {
            await _entities.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T model)
        {
            _entities.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int d)
        {
            T model = await GetById(d);
            _entities.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}