using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDecinding { get; set ; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnable { get; set; }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public BaseSpecification()
        {

        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)//function to get the value of sort and put it in the propof it to show if order by asc or desc
        {
            OrderBy = orderByExpression;
        }
        public void AddOrderByDecinding(Expression<Func<T, object>> orderByDecindingExpression)//function to get the value of sort and put it in the propof it to show if order by asc or desc
        {
            OrderByDecinding = orderByDecindingExpression;
        }
        public void ApplyPagination(int skip,int take)
        {
            IsPaginationEnable = true;
            Skip = skip;
            Take = take;
        }
    }
}
