using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2.Models;
using Moq;
using NUnit.Framework;
using Assignment_2.ViewModels.HelperClasses;

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
        public void TestGetAllModelsMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "all"},
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
                },
                new Ad()
                {
                    id = 2, userID = 2, location = "Teodor Mihali", price = 50000, size = 20
                }
            };

            var contextAssignment2Entities = new Assignment2Entities();
            contextAssignment2Entities.Ads = GetQueryableMockDbSet(

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

            var repo = new TestAdsRepository(contextAssignment2Entities.Ads, contextAssignment2Entities);
            var actual = RegularUserManageAdsHelper.GetAllModels(filter, repo, 2);
            CollectionAssert.AreEqual(expectedAds, actual);
        }

        [Test]
        public void TestGetModelByIdMethod()
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

            var contextAssignment2Entities = new Assignment2Entities();
            contextAssignment2Entities.Ads = GetQueryableMockDbSet(

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

            var repo = new TestAdsRepository(contextAssignment2Entities.Ads, contextAssignment2Entities);
            var actual = RegularUserManageAdsHelper.GetModelByIdHelper(filter, repo, 2);
            CollectionAssert.AreEqual(expectedAds, actual);
        }

        [Test]
        public void TestUpdateModelMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"userID", "2"},
                {"location", "Baritiu Street"},
                {"size", "30"},
                {"price", "70000"}
            };

            var expectedAds = new List<Ad>
            {
                new Ad
                {
                    id = 1,
                    userID = 2,
                    location = "Baritiu Street",
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
            };

            var contextAssignment2Entities = new Assignment2Entities();
            contextAssignment2Entities.Ads = GetQueryableMockDbSet(

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

            var repo = new TestAdsRepository(contextAssignment2Entities.Ads, contextAssignment2Entities);
            RegularUserManageAdsHelper.UpdateModel(filter, repo, 2);
            
            var actual = RegularUserManageAdsHelper.GetAllModels(filter, repo, 2);
            CollectionAssert.AreEqual(expectedAds, actual);
        }

        [Test]
        public void TestAddNewModelMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "4"},
                {"userID", "2"},
                {"location", "Aviatorilor"},
                {"size", "45"},
                {"price", "120000"}
            };

            var contextAssignment2Entities = new Assignment2Entities();
            contextAssignment2Entities.Ads = GetQueryableMockDbSet(

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

            var repo = new TestAdsRepository(contextAssignment2Entities.Ads, contextAssignment2Entities);
            RegularUserManageAdsHelper.AddNewModel(filter, repo, 2);
            //Assert.IsTrue(contextAssignment2Entities.ChangeTracker.HasChanges());
            //var now = contextAssignment2Entities.Ads;
            //bool addChange = contextAssignment2Entities.ChangeTracker.Entries().Any(e => e.State == EntityState.Added);
            //Assert.IsTrue(addChange);
        }
        
        [Test]
        public void TestDeleteModelMethod()
        {
            var filter = new Dictionary<string, string>
            {
                {"id", "1"},
                {"userID", ""},
                {"location", ""},
                {"size", ""},
                {"price", ""}
            };

            var contextAssignment2Entities = new Assignment2Entities();
            contextAssignment2Entities.Ads = GetQueryableMockDbSet(

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

            var repo = new TestAdsRepository(contextAssignment2Entities.Ads, contextAssignment2Entities);
            RegularUserManageAdsHelper.DeleteModel(filter, repo, 2);
            var markedAsDeleted = contextAssignment2Entities.Ads.Single(s => s.id == 1);

            Assert.IsTrue(contextAssignment2Entities.Entry(markedAsDeleted).State == EntityState.Deleted);
        }
    }
}
