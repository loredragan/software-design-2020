using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject;
namespace Server.Repository.Interfaces
{
    public interface IRepository<TModel> : ISave<TModel>, IRead<TModel>, ICommand<TModel>
        where TModel : class, IModel
    {
    }
}
