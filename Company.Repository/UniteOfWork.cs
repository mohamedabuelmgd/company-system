using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;
        public UniteOfWork(StoreContext context)
        {
            _context = context;
        }
        

        public void Dispose()
        {
            _context.Dispose();
         }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        { 
            //check if ther is repository is create befor
            if (_repositories == null)
                _repositories = new Hashtable();//if no create new hash table 
                                                //get type of repo that i want to create it
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))//check if i create one for this type before
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repository);
            }


            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
