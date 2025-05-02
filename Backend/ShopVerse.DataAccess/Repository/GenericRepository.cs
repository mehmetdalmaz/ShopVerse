using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;

namespace ShopVerse.DataAccess.Repository
{
    public class GenericRepository<T>: IGenericDal<T> where T : class
    {
        private readonly ShopVerseContext _context;
        public GenericRepository(ShopVerseContext context)
        {
            _context = context;
        }
       
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException("Entity not found");
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
             var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new NotImplementedException("Entity not found");
            }
        }

        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }
    }
   
}