using FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses.Interfaces
{
    public interface IFilterValidator<TModel> : IValidator
        where TModel : class, IModel
    {
        bool CheckIfQueryResultIsEmpty(IQueryable<TModel> queryResult);

        bool CheckIfArgumentIsNotDefault(string argument);
    }
}
