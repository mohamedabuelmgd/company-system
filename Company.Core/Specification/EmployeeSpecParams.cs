using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class EmployeeSpecParams
    {
        const int MaxPageSize = 5;
        private int PageSize=3;

        public int pageSize
        {
            get { return PageSize; }
            set { PageSize = value>pageSize?MaxPageSize:value; }
        }

        public int PageIndex { get; set; } = 1;
        public string Sort { get; set; }
        public int? ProjectId { get; set; }
        public int? DepartmentId { get; set; }
        private string Search;

        public string search
        {
            get { return Search; }
            set { Search = value.ToLower(); }
        }


    }
}
