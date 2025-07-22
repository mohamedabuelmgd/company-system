using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Core.Specification;
using Company.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        //make the clr generate object from the context to use the database
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }



        // to get all item that in the item user send in T data set
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllattendanceByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        // to get all item that in the item user send in T data set
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        // to get the item with the id  that in the item user send in T data set

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        // to get the item with the id  that in the item user send in T data set
        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByIdWithSpecAsyncList(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)//is a function that use to apply the specification by sed the entry point and spec to the specification class to get the query or generate it 
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);//send the entry point and specification to the clss to get query
        }
    }
}
