using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.ViewModels.RegularUser;
using Moq;
using NUnit.Framework;
using Server.RequestHandler.Users;

namespace Tests
{
    class RegularUserSearchAdsTests
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

            var ent = new Assignment3Entities();
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

            var mock = new Mock<RegularUserSearchAdsHandler>();
            mock.Setup(s => s.GetModelsFiltered(filter)).Returns(ads);

            var repo = new RegularUserManagePersonalAdsTests.TestAdsRepository(ent.Ads, ent);
            var handler = new RegularUserSearchAdsHandler();
            handler._repository = repo;

            var actual = handler.GetModelsFiltered(filter);
            CollectionAssert.AreEqual(mock.Object.GetModelsFiltered(filter), ads);
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

            var ent = new Assignment3Entities();
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

            var mock = new Mock<RegularUserSearchAdsHandler>();
            mock.Setup(s => s.GetModelsFiltered(filter)).Returns(ads);
            var repo = new RegularUserManagePersonalAdsTests.TestAdsRepository(ent.Ads, ent);
            var handler = new RegularUserSearchAdsHandler();
            handler._repository = repo;

            var actual = handler.GetModelsFiltered(filter);
            CollectionAssert.AreEqual(mock.Object.GetModelsFiltered(filter), ads);
        }
    }
}
