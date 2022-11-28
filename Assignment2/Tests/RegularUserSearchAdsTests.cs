using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Models;
using Assignment_2.Models.Repository;
using Assignment_2.Models.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using Assignment_2.ViewModels.ViewModels;
using Assignment_2.Views.HelperClasses;
using Assignment_2.ViewModels.HelperClasses;

namespace Tests
{
    [TestFixture]
    class RegularUserSearchAdsTests
    {
        [Test]
        public void TestSearchAllAds()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "all"},
                {"userID", "all"},
                {"location", "all"},
                {"size", "all"},
                {"price", "all"}
            };

            var ent = new Assignment2Entities();
            var ads = new List<Ad>
            {
                new Ad()
                {
                    id = 1, userID = 2, location = "Baritiu", price = 70000, size = 30
                },
                new Ad()
                {
                    id = 2, userID = 2, location = "Teodor Mihali", price = 50000, size = 20
                }
            };

            ent.Ads = GetQueryableMockDbSet(
            
                new Ad
                {
                    id = 1,
                    userID = 2,
                    location = "Baritiu",
                    price = 70000,
                    size = 30
                },
                new Ad()
                {
                    id = 2,
                    userID = 2,
                    location = "Teodor Mihali",
                    price = 50000,
                    size = 20
                }
            );

            var repo = new TestAdsRepository(ent.Ads, ent);
            var vm = new RegularUserSearchAdsViewModel(repo);
            var actual = vm.GetModelsFiltered(filter);
            CollectionAssert.AreEqual(ads, actual);
        }

        [Test]
        public void TestSearchAdsWithFilter()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "all"},
                {"userID", "all"},
                {"location", "all"},
                {"size", "30"},
                {"price", "70000"}
            };

            var ent = new Assignment2Entities();
            var ads = new List<Ad>
            {
                new Ad()
                {
                    id = 1, userID = 2, location = "Baritiu", price = 70000, size = 30
                },
            };

            ent.Ads = GetQueryableMockDbSet(

                new Ad
                {
                    id = 1,
                    userID = 2,
                    location = "Baritiu",
                    price = 70000,
                    size = 30
                }
            );

            var repo = new TestAdsRepository(ent.Ads, ent);
            var vm = new RegularUserSearchAdsViewModel(repo);
            var actual = vm.GetModelsFiltered(filter);
            CollectionAssert.AreEqual(ads, actual);
        }


        private static DbSet<T> GetQueryableMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return dbSet.Object;
        }
    }

    public class TestAdsRepository : IRepository<Ad>
    {
        private readonly DbSet<Ad> ads;
        private Assignment2Entities context;

        public TestAdsRepository(DbSet<Ad> ads, Assignment2Entities context)
        {
            this.ads = ads;
            this.context = context;
        }

        public void SaveChangesMethod()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                OnSaveValidateErrors(dbEx);
            }
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

        public Ad GetById(object Id)
        {
            return ads.Find(Id);
        }

        public IQueryable<Ad> GetAll()
        {
            return ads;
        }

        public DbSet<Ad> GetDbSet()
        {
            return ads;
        }

        public Ad GetByIdForGivenDbSet(DbSet<Ad> models, int id)
        {
            return models.Find(id);
        }

        public Ad Insert(Ad newObject)
        {
            ads.Add(newObject);
            SaveChangesMethod();
            return newObject;
        }

        public Ad Update(Ad obj)
        {
            ads.First(s => s.id.Equals(obj.id)).size = obj.size;
            ads.First(s => s.id.Equals(obj.id)).location = obj.location;
            ads.First(s => s.id.Equals(obj.id)).price = obj.price;
            ads.First(s => s.id.Equals(obj.id)).userID = obj.userID;

            return obj;
        }

        public void Delete(object id)
        {
            var toDelete = ads.Find(id);
            Delete(toDelete);
        }

        public void Delete(Ad entityToDelete)
        {
            ads.Remove(entityToDelete);
            context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
    }
}
