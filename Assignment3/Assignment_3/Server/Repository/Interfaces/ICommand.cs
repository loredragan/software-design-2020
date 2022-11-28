using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;

namespace Server.Repository.Interfaces
{
    public interface ICommand<TModel>
        where TModel : class, IModel
    {
        TModel Insert(TModel newObject);

        TModel Update(TModel obj);

        void Delete(object id);

        void Delete(TModel entityToDelete);

        void Dispose(bool disposing);
    }
}
