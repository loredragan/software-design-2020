using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;

namespace Server.Repository.Interfaces
{
    public interface IRepository<TModel> : ISave<TModel>, IRead<TModel>, ICommand<TModel>
        where TModel : class, IModel
    {
    }
}
