using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject;
using FinalProject.Models;
using Server.Repository.Interfaces;

namespace Server.Repository
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : class, IModel
    {
        private FinalProjectEntities _context { get; set; }
        internal DbSet<TModel> _dbSet { get; set; }

        public Repository(FinalProjectEntities context)
        {
            this._context = context;
            this._dbSet = _context.Set<TModel>();
        }

        public void OnSaveValidateErrors(DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }

        }

        public void SaveChangesMethod()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                OnSaveValidateErrors(dbEx);
            }
        }

        public IQueryable<TModel> GetAll()
        {
            return _dbSet;
        }

        public DbSet<TModel> GetDbSet()
        {
            return _dbSet;
        }

        public TModel GetByIdForGivenDbSet(DbSet<TModel> models, int id)
        {
            return models.Find(id);
        }

        public TModel GetById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public void Delete(object id)
        {
            TModel entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TModel entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            SaveChangesMethod();
        }

        public TModel Insert(TModel newObject)
        {
            _dbSet.Add(newObject);
            SaveChangesMethod();
            return newObject;
        }

        public TModel Update(TModel obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            SaveChangesMethod();
            return obj;
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
