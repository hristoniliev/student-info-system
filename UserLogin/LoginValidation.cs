using System;
using System.Collections.Generic;
using System.IO;

namespace UserLogin
{
     public class LoginValidation
    {
        private string _userName;
        private string _password;
        public string _errorMessage;
        private ActionOnError _actionOnError;
        public static string currentUserUsername;

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this._password = password;
            this._userName = username;
            this._actionOnError = actionOnError;
        }

        public static UserRoles CurrentUserRole { get; private set; }

        public bool ValidateUserInput(ref User user) {
            Boolean emptyUserName = _userName.Equals(String.Empty);
            if (emptyUserName == true) {
                _errorMessage = "Username not specified";
                _actionOnError(_errorMessage);
                return false;
            }
            Boolean emptyPassword = _password.Equals(String.Empty);
            if (emptyPassword == true) {
                _errorMessage = "Password not specified";
                _actionOnError(_errorMessage);
                return false;
            };
            if (_userName.Length < 5) {
                _errorMessage = "Too short. Username must be 5 characters at least";
                _actionOnError(_errorMessage);
                return false;
            }
            if (_password.Length < 5) {
                _errorMessage = "Too short. Password must be 5 characters at least";
                _actionOnError(_errorMessage);
                return false;
            };
            if (UserData.IsUserPassCorrect(_userName, _password) != null)
            {
                user = UserData.IsUserPassCorrect(_userName, _password);
                CurrentUserRole = (UserRoles)user.Role;
                if (user.DateValid > DateTime.Now)
                {

                    Logger.LogActivity("Login successful");
                    Console.WriteLine("\nLogin successful");
                }
                else
                {
                    Logger.LogActivity("Login unsuccessful. User expired");
                    _errorMessage = "Login unsuccessful. User expired";
                    _actionOnError(_errorMessage);
                    user = null;
                    return false;
                }

            }
            else {
                _errorMessage = "Username and password do not exist";
                _actionOnError(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            };
            
            return true;
        }

        public delegate void ActionOnError(string errorMsg);
        
    }
}
