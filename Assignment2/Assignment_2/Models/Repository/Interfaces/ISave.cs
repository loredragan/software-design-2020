using Assignment_2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models.Repository
{
    public interface ISave<TModel>
         where TModel : class, IModel
    {
        void SaveChangesMethod();

        void OnSaveValidateErrors(DbEntityValidationException dbEx);
    }
}
