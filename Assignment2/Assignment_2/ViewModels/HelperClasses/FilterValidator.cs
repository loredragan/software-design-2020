using Assignment_2.Model;
using Assignment_2.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Views.HelperClasses
{
    public class FilterValidator<TModel> : IFilterValidator<TModel>
        where TModel : class, IModel
    {
        #region Properties
        private const string _defaultValue = "all";
        #endregion

        #region Constructors
        public FilterValidator() { }
        #endregion

        public bool CheckIfArgumentIsNotDefault(string argument) => !argument.Equals(_defaultValue, StringComparison.InvariantCultureIgnoreCase) == true ? true : false;

        public bool CheckIfQueryResultIsEmpty(IQueryable<TModel> queryResult) => !queryResult.Any();
    }
}
