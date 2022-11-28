using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.DomainLayer.HelperClasses;

namespace Assignment1.PresentationLayer.HelperClasses
{
    //id, type, amount, creationDate, clientID
    static class EmployeeAccountsInputValidator
    {
        public static ValidationResult ValidateInputsForFindByAccountId(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the account you want to find");
            }

            if (!((string.IsNullOrEmpty(valuePairs["type"])) &&
                  (string.IsNullOrEmpty(valuePairs["amount"])) &&
                  //(string.IsNullOrEmpty(valuePairs["creationDate"])) &&
                  (string.IsNullOrEmpty(valuePairs["clientID"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForDeleteModelById(IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["id"]) || valuePairs["id"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the id for the account you want to delete");
            }

            if (!((string.IsNullOrEmpty(valuePairs["type"])) &&
                  (string.IsNullOrEmpty(valuePairs["amount"])) &&
                  //(string.IsNullOrEmpty(valuePairs["creationDate"])) &&
                  (string.IsNullOrEmpty(valuePairs["clientID"]))
                ))
            {
                return new ValidationResult(false, "Only id should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForFindAccountsForClientGivenById(
            IDictionary<string, string> valuePairs)
        {
            if (string.IsNullOrWhiteSpace(valuePairs["clientID"]) || valuePairs["clientID"].Equals(string.Empty))
            {
                return new ValidationResult(false, "Insert the client id to find all it's associated accounts");
            }

            if (!((string.IsNullOrEmpty(valuePairs["id"])) &&
                  (string.IsNullOrEmpty(valuePairs["type"])) &&
                  (string.IsNullOrEmpty(valuePairs["amount"]))))
                  //(string.IsNullOrEmpty(valuePairs["creationDate"]))
                
            {
                return new ValidationResult(false, "Only clientID should contain a value");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForAddNewModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["type"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["amount"]) ||
                 //string.IsNullOrWhiteSpace(valuePairs["creationDate"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["clientID"])))
            {
                return new ValidationResult(false, "Insert values for the new account");
            }

            if (!(string.IsNullOrEmpty(valuePairs["id"])))
            {
                return new ValidationResult(false, "Do not insert the id for the new account." + Environment.NewLine + " it will be set automatically");
            }

            double newAmount;
            try
            {
                newAmount = Convert.ToDouble(valuePairs["amount"]);
                //newClientId = Convert.ToInt32(valuePairs["clientID"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "amount");
            }

            if (OnCreateValidateAccount.IsEntityValid( newAmount, valuePairs["type"]) ==
                false)
            {
                return new ValidationResult(false, "The values for the new account are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForUpdateModel(IDictionary<string, string> valuePairs)
        {
            if ((string.IsNullOrWhiteSpace(valuePairs["type"]) ||
                 string.IsNullOrWhiteSpace(valuePairs["amount"])
                 //string.IsNullOrWhiteSpace(valuePairs["creationDate"]) ||
                 /*string.IsNullOrWhiteSpace(valuePairs["clientID"])*/))
            {
                return new ValidationResult(false, "Columns type, amount should contain values");
            }

            if (string.IsNullOrEmpty(valuePairs["id"]))
            {
                return new ValidationResult(false, "Insert the id for the account you want to update");
            }

            if (!string.IsNullOrEmpty(valuePairs["clientID"]))
            {
                return new ValidationResult(false,
                    "Client id should be empty because you can't move an account from one person to another");
            }


            double newAmount;
            try
            {
                newAmount = Convert.ToDouble(valuePairs["amount"]);
                //newClientId = Convert.ToInt32(valuePairs["clientID"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "amount");
            }

            if (OnCreateValidateAccount.IsEntityValid(newAmount, valuePairs["type"]) ==
                false)
            {
                return new ValidationResult(false, "The values for the new account are invalid");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForTransferAmount(IDictionary<string, string> valuePairs)
        {
            if (!((string.IsNullOrEmpty(valuePairs["type"])) &&
                  (string.IsNullOrEmpty(valuePairs["amount"])) &&
                  (string.IsNullOrEmpty(valuePairs["id"])) &&
                  (string.IsNullOrEmpty(valuePairs["clientID"]))
                ))
            {
                return new ValidationResult(false, "id, type, amount, clientID should not contain values");
            }

            if (string.IsNullOrWhiteSpace(valuePairs["fromAccount"]) || 
                valuePairs["fromAccount"].Equals(string.Empty)       ||
                string.IsNullOrEmpty(valuePairs["toAccount"])        ||
                valuePairs["toAccount"].Equals(string.Empty)         ||
                string.IsNullOrWhiteSpace(valuePairs["TransferSum"]) ||
                valuePairs["TransferSum"].Equals(string.Empty))

            {
                return new ValidationResult(false, "Source Account ID , Destination Account ID or " + Environment.NewLine +
                                                            "the amount to be transferred are missing");
            }

            double toBeTransferred;

            try
            {
                toBeTransferred = Convert.ToDouble(valuePairs["TransferSum"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid amount");
            }

            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult ValidateInputsForPayUtilities(IDictionary<string, string> valuePairs)
        {
            if (!((string.IsNullOrEmpty(valuePairs["type"]))    &&
                  (string.IsNullOrEmpty(valuePairs["amount"]))  &&
                  (string.IsNullOrEmpty(valuePairs["id"]))      &&
                  (string.IsNullOrEmpty(valuePairs["clientID"]) &&
                  (string.IsNullOrEmpty(valuePairs["fromAccount"])) &&
                  (string.IsNullOrEmpty(valuePairs["toAccount"]))  &&
                  (string.IsNullOrEmpty(valuePairs["TransferSum"]))
                  )
                ))
            {
                return new ValidationResult(false, "id, type, amount, clientID, and Transfer amount "
                                                   +Environment.NewLine+" should not contain values");
            }

            if (string.IsNullOrWhiteSpace(valuePairs["UtilitySum"]) ||
                valuePairs["UtilitySum"].Equals(string.Empty) ||
                string.IsNullOrEmpty(valuePairs["idUtility"]) ||
                valuePairs["idUtility"].Equals(string.Empty)
               )

            {
                return new ValidationResult(false, "ID account and the amount to pay should contain a value");
            }

            double toBePaid;

            try
            {
                toBePaid = Convert.ToDouble(valuePairs["UtilitySum"]);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid amount");
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
