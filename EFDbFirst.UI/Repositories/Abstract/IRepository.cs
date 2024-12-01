using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbFirst.UI.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        bool Create(T data);
        bool Update(T data);   

        bool Delete(T data); 

        T GetById(int id);

        List<T> GetAll();

       

        
    }
}
