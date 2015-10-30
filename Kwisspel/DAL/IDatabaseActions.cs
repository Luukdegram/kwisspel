using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.DAL
{
    interface IDatabaseActions<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Show(int id);
        List<T> All();
    }
}
