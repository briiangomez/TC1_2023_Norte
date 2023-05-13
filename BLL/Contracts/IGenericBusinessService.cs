using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IGenericBusinessService<T>
    {
        void Insert(T obj);

        void Delete(Guid id);

        void Update(T obj);

        T GetOne(Guid id);

        IEnumerable<T> GetAll();

    }
}
