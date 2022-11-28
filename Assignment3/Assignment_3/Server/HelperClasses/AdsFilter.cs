using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Server.Exceptions;
using Server.HelperClasses.Interfaces;

namespace Server.HelperClasses
{
    static class AdsFilter
    {
        public static IEnumerable<Ad> Filter(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["id"]))
            {
                var requestedId = 0;
                try
                {
                    requestedId = Convert.ToInt32(filterRequest["id"]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid ID");
                }
                adsQueryable = adsQueryable.Where(ad => ad.id == requestedId);
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["userID"]))
            {
                var userId = 0;
                try
                {
                    userId = Convert.ToInt32(filterRequest["userID"]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid User ID");
                }
                adsQueryable = adsQueryable.Where(ad => ad.userID == userId);
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["location"]))
            {
                var requestedLocation = filterRequest["location"];
                adsQueryable = adsQueryable.Where(ad => ad.location.Equals(requestedLocation, StringComparison.InvariantCultureIgnoreCase));
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["size"]))
            {
                var size = 0.0;
                try
                {
                    size = Convert.ToDouble(filterRequest["size"]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid Size");
                }
                adsQueryable = adsQueryable.Where(ad => ad.size == size);
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["price"]))
            {
                var price = 0.0;
                try
                {
                    price = Convert.ToDouble(filterRequest["price"]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid Price");
                }
                adsQueryable = adsQueryable.Where(ad => ad.price == price);
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }

            return adsQueryable.ToList();
        }
    }
}

