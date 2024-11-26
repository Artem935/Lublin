using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.OrderByCondition
{
    internal interface IAbstractionSorting<T>
    {
        public List<T> SortAscendingPrice(List<T> transport);
        public List<T> SortDescendingPrice(List<T> transport);
    }
}
