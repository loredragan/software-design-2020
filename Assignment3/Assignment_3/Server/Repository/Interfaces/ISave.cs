using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;

namespace Server.Repository.Interfaces
{
    public interface ISave<TModel>
        where TModel : class, IModel
    {
        void SaveChangesMethod();

        void OnSaveValidateErrors(DbEntityValidationException dbEx);
    }
}
