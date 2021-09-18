using BankingManagementSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankingManagementSystem.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext ApplicationContext { get; set; }
        public RepositoryBase(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.ApplicationContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationContext.Set<T>().Where(expression).AsNoTracking();
        }
        public async Task CreateAsync(T entity)
        {
            await this.ApplicationContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            this.ApplicationContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.ApplicationContext.Set<T>().Remove(entity);
        }
    }
}
