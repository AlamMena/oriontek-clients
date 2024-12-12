using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OriontekClientsServer.Domain.Common;
using OriontekClientsServer.Domain.Exceptions;
using OriontekClientsServer.Domain.Repositories;
using OriontekClientsServer.Infrastucture.Persitence.Contexts;
using System.Linq.Expressions;

namespace OriontekClientsServer.Infrastucture.Persitence.Repositories.core
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly ApplicationContext _dbContext;
        protected DbSet<T> Entities;

        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                await Entities.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            try
            {
                if (entity is CoreEntity entityModel)
                {
                    entityModel.IsDeleted = true;
                    Entities.Update(entity);
                    await _dbContext.SaveChangesAsync();
                }

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = await Entities.FindAsync(entity.Id);
                if (entry != null)
                {
                    _dbContext.Entry(entry).CurrentValues.SetValues(entity);
                    await _dbContext.SaveChangesAsync();
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await Entities.FindAsync(id); ;
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Entities.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }

        }

        public async Task<IEnumerable<T>> GetAllPaginatedAsync(int page, int limit)
        {
            try
            {
                return await Entities
                    .Skip(limit * (page - 1))
                    .Take(limit)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await Entities.CountAsync();

            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, 500);
            }
        }

    }
}
