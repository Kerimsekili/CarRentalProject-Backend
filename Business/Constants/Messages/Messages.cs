using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants.Messages
{
    public class Messages
    {
        public static string PasswordError = "Password Error !";
        public static string GeneralAdded = "Adding was successful.";
        public static string GeneralListed = "Listing successful.";
        public static string CarNameInvalid = "Car name is invalid.";
        public static string GeneralUpdate = "The update was successful.";
        public static string GeneralDelete = "The deletion was successful.";
        public static string MaintenanceTime = "The system is maintence.";
        public static string UpdateFailed = "The operation failed.";
        public static string RentalFailed = "The rental operation is failed.";
        public static string CarCountOfCategoryError = "Araba Sayısı Kategorisi aşıldı";

        public static string CarImageAdded = "Category Exceeded";
        public static string CarImageDeleted = "Car Picture Deleted";
        public static string CarImageUpdated = "Car Picture Updated";
        public static string UserNotFound = "User not found";
        public static string SuccessfulLogin="Login Successful";
        public static string UserAlreadyExist = "User Already Exist";
        public static string UserRegistered = "User Successfully Registered";
        public static string AccessTokenCreated = "Access token created";
        public static string AuthorizationDenied = "Authorization denied.";
    }
}
