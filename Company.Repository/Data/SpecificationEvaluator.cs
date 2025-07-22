using Company.Core.Entities;
using Company.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Data
{
    public class SpecificationEvaluator<T> where T :BaseEntity
    {
        //function to build dynamic query
        public static IQueryable<T> GetQuery(IQueryable<T> EntryPoint,ISpecification<T> Spec)
        {
            //the query statrt with the entry poin 
            
            var query = EntryPoint;//_context.set<Tclassname>()
            if (Spec.Criteria!=null)//show if the query contain where condition or no
                query=query.Where(Spec.Criteria);//if contain the query wil be like _context.set<Tclassname>().where(p=>p.condition)
            if (Spec.IsPaginationEnable)//if you need the pagination 
                query = query.Skip(Spec.Skip).Take(Spec.Take); //the query wil be like _context.set<Tclassname>().where(p => p.condition).skip(num).take(num)
            if (Spec.OrderBy != null)//show if the query contain order by  or no
                query = query.OrderBy(Spec.OrderBy);//if contain the query wil be like _context.set<Tclassname>().where(p => p.condition).skip(num).take(num).orderby(p=>p.whatiwanttoorderwithit)
            if (Spec.OrderByDecinding != null)//show if the query contain order by desc  or no
                query = query.OrderByDescending(Spec.OrderByDecinding);//if contain the query wil be like _context.set<Tclassname>().where(p => p.condition).skip(num).take(num).orderbydecinding(p=>p.whatiwanttoorderwithit
            query = Spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));//make the includes to the query 
            //_context.set<Tclassname>().where(p=>p.condition).skip(num).take(num).orderbyascordes(p=>p.whatiwanttoorderwithit).include (p=>p.the classnavigation name
            return query;
        }
    }
}
