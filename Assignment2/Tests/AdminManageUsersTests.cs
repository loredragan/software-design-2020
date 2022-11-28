using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Models;
using Assignment_2.Models.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using Assignment_2.ViewModels.HelperClasses;

namespace Tests
{
    [TestFixture]
    class AdminManageUsersTests
    {
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

        [Test]
        public void TestGetAllMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", ""},
                {"username", ""},
                {"password", ""},
                {"name", ""}
            };

            var expectedUsers = new List<User>
            {
                new User()
                {
                    id = 1,
                    username = "Lorena",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            };

            var context = new Assignment2Entities();
            context.Users = GetQueryableMockDbSet(
                new User()
                {
                    id = 1,
                    username = "Lorena",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            );

            var repo = new TestUsersRepository(context.Users, context);
            var actual = AdminManageUsersHelper.GetAllModels(filter, repo, 1);
            CollectionAssert.AreEqual(expectedUsers, actual);
        }

        [Test]
        public void TestGetModelById()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "2"},
                {"username", ""},
                {"password", ""},
                {"name", ""}
            };

            var expectedUsers = new List<User>
            {
                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            };

            var context = new Assignment2Entities();
            context.Users = GetQueryableMockDbSet(
                new User()
                {
                    id = 1,
                    username = "Lorena",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            );

            var repo = new TestUsersRepository(context.Users, context);
            var actual = AdminManageUsersHelper.GetModelById(filter, repo, 1);
            CollectionAssert.AreEqual(expectedUsers, actual);
        }


        [Test]
        public void TestUpdateModelMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"username", "LorenaDiana"},
                {"password", "1234"},
                {"name", "Lorena Dragan"}
            };

            var expectedUsers = new List<User>
            {
                new User()
                {
                    id = 1,
                    username = "LorenaDiana",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            };

            var context = new Assignment2Entities();
            context.Users = GetQueryableMockDbSet(
                new User()
                {
                    id = 1,
                    username = "Lorena",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            );

            var repo = new TestUsersRepository(context.Users, context);
            AdminManageUsersHelper.UpdateModel(filter, repo, 1);

            var actual = AdminManageUsersHelper.GetAllModels(filter, repo, 1);
            CollectionAssert.AreEqual(expectedUsers, actual);
        }

        [Test]
        public void TestDeleteModelMethod()
        {

            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"username", ""},
                {"password", ""},
                {"name", ""}
            };

            var context = new Assignment2Entities();
            context.Users = GetQueryableMockDbSet(
                new User()
                {
                    id = 1,
                    username = "Lorena",
                    password = "1234",
                    name = "Lorena Dragan"
                },

                new User()
                {
                    id = 2,
                    username = "Claudia",
                    password = "0000",
                    name = "Claudia Dragan"
                }
            );

            var repo = new TestUsersRepository(context.Users, context);
            AdminManageUsersHelper.DeleteModel(filter, repo, 1);
            var markedAsDeleted = context.Users.Single(s => s.id == 1);

            Assert.IsTrue(context.Entry(markedAsDeleted).State == EntityState.Deleted);
        }
    }

    public class TestUsersRepository : IRepository<User>
    {
        private readonly DbSet<User> users;
        private Assignment2Entities context;

        public TestUsersRepository(DbSet<User> users, Assignment2Entities context)
        {
            this.users = users;
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

        public User GetById(object Id)
        {
            var requested = Convert.ToInt32(Id);
            return users.Single(s => s.id == requested);
        }

        public IQueryable<User> GetAll()
        {
            return users;
        }

        public DbSet<User> GetDbSet()
        {
            return users;
        }

        public User GetByIdForGivenDbSet(DbSet<User> models, int id)
        {
            return models.Find(id);
        }

        public User Insert(User newObject)
        {
            users.Add(newObject);
            SaveChangesMethod();
            return newObject;
        }

        public User Update(User obj)
        {
            users.First(s => s.id.Equals(obj.id)).password = obj.password;
            users.First(s => s.id.Equals(obj.id)).username = obj.username;
            users.First(s => s.id.Equals(obj.id)).name = obj.name;

            return obj;
        }

        public void Delete(object id)
        {
            var toDelete = users.Find(id);
            Delete(toDelete);
        }

        public void Delete(User entityToDelete)
        {
            users.Remove(entityToDelete);
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
