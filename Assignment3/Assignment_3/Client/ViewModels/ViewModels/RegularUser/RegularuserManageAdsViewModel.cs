using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Exceptions;
using Client.ViewModels.HelperClasses;
using Client.ViewModels.Interfaces;
using Client.Views.Interfaces;

namespace Client.ViewModels.ViewModels.RegularUser
{
    class RegularUserManageAdsViewModel : RegularUserViewModel<Ad>
    {
        #region Constructors
        public RegularUserManageAdsViewModel(IMessageBoxService messageBoxSerivce, ICrudValidator validator)
            : base(messageBoxSerivce, validator) { }
        #endregion

        public IEnumerable<Ad> GetModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            return RegularUserManageAdsHelper.GetModelByIdHelper(valuePairs, authenticatedUser);
        }

        public void UpdateModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.UpdateModel(valuePairs, authenticatedUser);
        }

        public void DeleteModelById(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.DeleteModel(valuePairs, authenticatedUser);
        }

        public void AddNewModel(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.AddNewModel(valuePairs, authenticatedUser);
        }

        public IEnumerable<Ad> GetAllModels(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserManageAdsHelper.GetAllModels(valuePairs, authenticatedUser);
        }

        public void AddToFavorites(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if (!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.AddToFavourites(valuePairs, authenticatedUser);
        }

        public IEnumerable<Favorite> GetAllFavorites(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserManageAdsHelper.GetFavouriteModels(valuePairs, authenticatedUser);
        }

        public void SendMessage(IDictionary<string, string> valuePairs, ValidationResult validationResult, int authenticatedUser)
        {
            if(!validationResult.IsValid)
                throw new InvalidInputException(validationResult.ValidationResultMessage);

            RegularUserManageAdsHelper.SendMessage(valuePairs, authenticatedUser);
        }

        public IEnumerable<ChatMessage> GetInbox(IDictionary<string, string> valuePairs, int authenticatedUser)
        {
            return RegularUserManageAdsHelper.GetInbox(valuePairs, authenticatedUser);
        }
    }
}
