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
        protected ApplicationContext applicationContext { get; set; }
        public RepositoryBase(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.applicationContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.applicationContext.Set<T>().Where(expression).AsNoTracking();
        }
        public async Task CreateAsync(T entity)
        {
            await this.applicationContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            this.applicationContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.applicationContext.Set<T>().Remove(entity);
        }
    }
}
