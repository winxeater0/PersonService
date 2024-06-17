using PersonService.Domain.Interfaces.Repositories;
using PersonService.Infrastrusture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity entity)
        {
            try
            {
                sqlContext.Set<TEntity>().Add(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                sqlContext.Set<TEntity>().Remove(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            try
            {
                sqlContext.Entry(entity).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
