using FinalProject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interfaces
{
    public interface ISave<TModel>
        where TModel : class, IModel
    {
        void SaveChangesMethod();

        void OnSaveValidateErrors(DbEntityValidationException dbEx);
    }
}
