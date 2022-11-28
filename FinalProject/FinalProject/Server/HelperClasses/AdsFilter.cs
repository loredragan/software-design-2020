using FinalProject.Models;
using Server.Exceptions;
using Server.HelperClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.HelperClasses
{
    class AdsFilter
    {
        //inainte era static class
        public static IEnumerable<Ad> Filter(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
            #region before
            ////id
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["id"]))
            //{
            //    var requestedId = 0;
            //    try
            //    {
            //        requestedId = Convert.ToInt32(filterRequest["id"]);
            //    }
            //    catch (FormatException)
            //    {
            //        throw new FormatException("Invalid ID");
            //    }
            //    adsQueryable = adsQueryable.Where(ad => ad.id == requestedId);
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}

            ////userID
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["userID"]))
            //{
            //    var userId = 0;
            //    try
            //    {
            //        userId = Convert.ToInt32(filterRequest["userID"]);
            //    }
            //    catch (FormatException)
            //    {
            //        throw new FormatException("Invalid User ID");
            //    }
            //    adsQueryable = adsQueryable.Where(ad => ad.userId == userId);
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}

            ////location
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["location"]))
            //{
            //    var requestedLocation = filterRequest["location"];
            //    adsQueryable = adsQueryable.Where(ad => ad.location.Equals(requestedLocation, StringComparison.InvariantCultureIgnoreCase));
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}

            ////size
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["size"]))
            //{
            //    var size = 0.0;
            //    try
            //    {
            //        size = Convert.ToDouble(filterRequest["size"]);
            //    }
            //    catch (FormatException)
            //    {
            //        throw new FormatException("Invalid Size");
            //    }
            //    adsQueryable = adsQueryable.Where(ad => ad.size == size);
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}

            ////price
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["price"]))
            //{
            //    var price = 0.0;
            //    try
            //    {
            //        price = Convert.ToDouble(filterRequest["price"]);
            //    }
            //    catch (FormatException)
            //    {
            //        throw new FormatException("Invalid Price");
            //    }
            //    adsQueryable = adsQueryable.Where(ad => ad.price == price);
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}

            ////rating
            //if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["rating"]))
            //{
            //    var rating = 0;
            //    try
            //    {
            //        rating = Convert.ToInt32(filterRequest["rating"]);
            //    }
            //    catch (FormatException)
            //    {
            //        throw new FormatException("Invalid Rating");
            //    }
            //    adsQueryable = adsQueryable.Where(ad => ad.rating == rating);
            //    if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
            //        throw new NoResultException(_adsNotFound);
            //}
            #endregion

            adsQueryable = SearchById(adsQueryable, AdsValidator, filterRequest, _adsNotFound);
            adsQueryable = SearchByUserId(adsQueryable, AdsValidator, filterRequest, _adsNotFound);
            adsQueryable = SearchByLocation(adsQueryable, AdsValidator, filterRequest, _adsNotFound);
            adsQueryable = SearchBySize(adsQueryable, AdsValidator, filterRequest, _adsNotFound);
            adsQueryable = SearchByPrice(adsQueryable, AdsValidator, filterRequest, _adsNotFound);
            return adsQueryable.ToList();
        }

        public static IQueryable<Ad> SearchByPrice(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
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

            return adsQueryable;
        }

        public static IQueryable<Ad> SearchBySize(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
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

            return adsQueryable;
        }

        public static IQueryable<Ad> SearchByLocation(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["location"]))
            {
                var requestedLocation = filterRequest["location"];
                adsQueryable = adsQueryable.Where(ad => ad.location.Equals(requestedLocation, StringComparison.InvariantCultureIgnoreCase));
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }

            return adsQueryable;
        }

        public static IQueryable<Ad> SearchByUserId(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
        {
            if (AdsValidator.CheckIfArgumentIsNotDefault(filterRequest["userId"]))
            {
                var userId = 0;
                try
                {
                    userId = Convert.ToInt32(filterRequest["userId"]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid User ID");
                }
                adsQueryable = adsQueryable.Where(ad => ad.userId == userId);
                if (AdsValidator.CheckIfQueryResultIsEmpty(adsQueryable))
                    throw new NoResultException(_adsNotFound);
            }

            return adsQueryable;
        }

        public static IQueryable<Ad> SearchById(IQueryable<Ad> adsQueryable, IFilterValidator<Ad> AdsValidator, IDictionary<string, string> filterRequest, string _adsNotFound)
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

            return adsQueryable;
        }
    }
}
