using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Colegio.BL.Data;
using Colegio.BL.Models;

namespace Colegio.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly ColegioContext colegioContext;

        public GenericRepository(ColegioContext ColegioContext)
        {
            this.colegioContext = ColegioContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            colegioContext.Set<TEntity>().Remove(entity);
            await colegioContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await colegioContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await colegioContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            colegioContext.Set<TEntity>().Add(entity);
            await colegioContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //colegioContext.Entry(entity).State = EntityState.Modified;
            colegioContext.Set<TEntity>().AddOrUpdate(entity);
            await colegioContext.SaveChangesAsync();
            return entity;
        }
    }
}
