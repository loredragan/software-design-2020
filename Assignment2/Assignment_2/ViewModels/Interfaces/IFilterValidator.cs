using Assignment_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.Interfaces
{
    public interface IFilterValidator<TModel> : IValidator
        where TModel : class, IModel
    {
        bool CheckIfQueryResultIsEmpty(IQueryable<TModel> queryResult);

        bool CheckIfArgumentIsNotDefault(string argument);
    }
}
