using FinalProject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interfaces
{
    public interface IRead<TModel>
        where TModel : class, IModel
    {
        TModel GetById(object Id);
        IQueryable<TModel> GetAll();
        DbSet<TModel> GetDbSet();
        TModel GetByIdForGivenDbSet(DbSet<TModel> models, int id);
    }
}
