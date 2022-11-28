using Assignment_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models.Repository.Interfaces
{
    public interface IRepository<TModel> : ISave<TModel>, IRead<TModel>, ICommand<TModel>
        where TModel : class, IModel
    {
    }
}
