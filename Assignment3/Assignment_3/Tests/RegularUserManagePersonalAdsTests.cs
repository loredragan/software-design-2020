using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.HelperClasses;
using Moq;
using NUnit.Framework;
using Server.Repository.Interfaces;
using Server;
using Server.RequestHandler.Users;

namespace Tests
{
    [TestFixture]
    class RegularUserManagePersonalAdsTests
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
        public void TestGetAllModelsMethodServer()
        {
            //filter for request
            var filter = new Dictionary<string, string>
            {
                {"id", "all"},
                {"userID", "1"},
                {"location", "all"},
                {"size", "all"},
                {"price", "all"}
            };

            //expected result
            var expectedAds = new List<Ad>
            {
                new Ad()
                {
                    id = 1, userID = 1, location = "Aurel Vlaicu", price = 70000, size = 30
                },
                new Ad()
                {
                    id = 2, userID = 1, location = "Teodor Mihali", price = 50000, size = 20
                }
            };

            var mockRegularuserManageAdsHelper = new Mock<RegularUserManageAdsHelper>();
            mockRegularuserManageAdsHelper.Setup(x => x.GetAllModelsTest(filter, 1)).Returns(expectedAds);

            #region Seed
            var contextAssignment3Entities = new Assignment3Entities();
            contextAssignment3Entities.Ads = GetQueryableMockDbSet(
                new Ad
                {
                    id = 1,
                    userID = 1,
                    location = "Aurel Vlaicu",
                    price = 70000,
                    size = 30
                },
                new Ad()
                {
                    id = 2,
                    userID = 1,
                    location = "Teodor Mihali",
                    price = 50000,
                    size = 20
                },
                new Ad()
                {
                    id = 3,
                    userID = 2,
                    location = "Teodor Mihali",
                    price = 50000,
                    size = 20
                },
                new Ad()
                {
                    id = 4,
                    userID = 2,
                    location = "Parasutistilor",
                    price = 50000,
                    size = 20
                }
            );
            #endregion

            var repo = new TestAdsRepository(contextAssignment3Entities.Ads, contextAssignment3Entities);
            var handlerFromServer = new RegularUserManageAdsHandler();
            handlerFromServer._repository = repo;

            var actual = handlerFromServer.GetAllModels(filter, 1);
            CollectionAssert.AreEqual(mockRegularuserManageAdsHelper.Object.GetAllModelsTest(filter, 1), actual);
        }

        [Test]
        public void TestGetModelByIdHelperTest()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"userID", "2"},
                {"location", "all"},
                {"size", "all"},
                {"price", "all"}
            };

            var expectedAds = new List<Ad>
            {
                new Ad()
                {
                    id = 1, userID = 2, location = "Baritiu", price = 70000, size = 30
                }
            };

            var mockRegularuserManageAdsHelper = new Mock<RegularUserManageAdsHelper>();
            mockRegularuserManageAdsHelper.Setup(x => x.GetModelByIdHelperTest(filter, 2)).Returns(expectedAds);

            var contextAssignment3Entities = new Assignment3Entities();
            contextAssignment3Entities.Ads = GetQueryableMockDbSet(

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
                },

                new Ad()
                {
                    id = 3,
                    userID = 1,
                    location = "Teodor Mihali",
                    price = 50000,
                    size = 20
                }
            );

            var repo = new TestAdsRepository(contextAssignment3Entities.Ads, contextAssignment3Entities);
            var handlerFromServer = new RegularUserManageAdsHandler();
            handlerFromServer._repository = repo;

            var actual = handlerFromServer.GetModelById(filter, 2);
            CollectionAssert.AreEqual(mockRegularuserManageAdsHelper.Object.GetModelByIdHelperTest(filter, 2), actual);
        }

        [Test]
        public void TestGetFavouriteModelsTest()
        {
            var filter = new Dictionary<string, string>()
            {
                {"id", "all"},
                {"userID", "all"},
                {"location", "all"},
                {"size", "all"},
                {"price", "all"}
            };

            var expectedFav = new List<Favorite>()
            {
                new Favorite()
                {
                    id=1,
                    userID = 1,
                    adID = 1,
                    ownerID = 2
                },

                new Favorite()
                {
                    id=2,
                    userID = 1,
                    adID = 2,
                    ownerID = 2
                }
            };

            #region Seed
            var contextAssignment3Entities = new Assignment3Entities();
            contextAssignment3Entities.Favorites = GetQueryableMockDbSet(
                new Favorite()
                {
                    id = 1,
                    userID = 1,
                    adID = 1,
                    ownerID = 2
                },
                new Favorite()
                {
                    id = 2,
                    userID = 1,
                    adID = 2,
                    ownerID = 2
                },
                new Favorite()
                {
                    id = 3,
                    userID = 2,
                    adID = 2,
                    ownerID = 3
                }
            );
            #endregion

            var mockRegularuserManageAdsHelper = new Mock<RegularUserManageAdsHelper>();
            mockRegularuserManageAdsHelper.Setup(x => x.GetFavouriteModelsTest(filter, 1)).Returns(expectedFav);

            var repo = new TestFavoritesRepository(contextAssignment3Entities.Favorites, contextAssignment3Entities);
            var handlerFromServer = new RegularUserManageAdsHandler();
            handlerFromServer.favorites = repo;

            var actual = handlerFromServer.GetAllFavourites(filter, 1);
            CollectionAssert.AreEqual(mockRegularuserManageAdsHelper.Object.GetFavouriteModelsTest(filter, 1), actual);
        }

        [Test]
        public void TestValidInputForUpdateModel()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"userID", ""},
                {"location", "lala"},
                {"size", "234"},
                {"price", "234"},
                {"adID", ""}

            };

            var validator = new Mock<UserManagePersonalAdsValidator>();
            validator.Setup(s => s.ValidateInputsForUpdateModel(filter)).Returns(new ValidationResult(true, string.Empty));

            var validatorTrue = new UserManagePersonalAdsValidator();
            var result = validatorTrue.ValidateInputsForUpdateModel(filter);

            Assert.AreEqual(validator.Object.ValidateInputsForUpdateModel(filter).IsValid, result.IsValid);
        }

        [Test]
        public void TestValidInputForDeleteModel()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"userID", ""},
                {"location", ""},
                {"size", ""},
                {"price", ""},
                {"adID", ""}

            };

            var validator = new Mock<UserManagePersonalAdsValidator>();
            validator.Setup(s => s.ValidateInputsForDeleteModel(filter)).Returns(new ValidationResult(true, string.Empty));

            var validatorTrue = new UserManagePersonalAdsValidator();
            var result = validatorTrue.ValidateInputsForDeleteModel(filter);

            Assert.AreEqual(validator.Object.ValidateInputsForDeleteModel(filter).IsValid, result.IsValid);
        }

        [Test]
        public void TestValidInputForSendMessage()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", ""},
                {"userID", "1"},
                {"location", ""},
                {"size", ""},
                {"price", ""},
                {"adID", ""},
                {"messageContent", "lala"}
            };

            var validator = new Mock<UserManagePersonalAdsValidator>();
            validator.Setup(s => s.ValidateInputsForSendMessage(filter)).Returns(new ValidationResult(true, string.Empty));

            var validatorTrue = new UserManagePersonalAdsValidator();
            var result = validatorTrue.ValidateInputsForSendMessage(filter);

            Assert.AreEqual(validator.Object.ValidateInputsForSendMessage(filter).IsValid, result.IsValid);
        }

        #region mocked Repo
        public class TestAdsRepository : IRepository<Ad>
        {
            private readonly DbSet<Ad> ads;
            private Assignment3Entities context;

            public TestAdsRepository(DbSet<Ad> ads, Assignment3Entities context)
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

        public class TestFavoritesRepository : IRepository<Favorite>
        {
            private readonly DbSet<Favorite> ads;
            private Assignment3Entities context;

            public TestFavoritesRepository(DbSet<Favorite> ads, Assignment3Entities context)
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

            public Favorite GetByIdForGivenDbSet(DbSet<Favorite> models, int id)
            {
                return models.Find(id);
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

            public Favorite GetById(object Id)
            {
                return ads.Find(Id);
            }

            public IQueryable<Favorite> GetAll()
            {
                return ads;
            }

            public DbSet<Favorite> GetDbSet()
            {
                return ads;
            }

            public Ad GetByIdForGivenDbSet(DbSet<Ad> models, int id)
            {
                return models.Find(id);
            }

            public Favorite Insert(Favorite newObject)
            {
                ads.Add(newObject);
                SaveChangesMethod();
                return newObject;
            }

            public Favorite Update(Favorite obj)
            {
                ads.First(s => s.id.Equals(obj.id)).adID = obj.adID;
                ads.First(s => s.id.Equals(obj.id)).ownerID = obj.ownerID;
                ads.First(s => s.id.Equals(obj.id)).userID = obj.userID;

                return obj;
            }

            public void Delete(object id)
            {
                var toDelete = ads.Find(id);
                Delete(toDelete);
            }

            public void Delete(Favorite entityToDelete)
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
        #endregion
    }
}
