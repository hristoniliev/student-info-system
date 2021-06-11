using System;
using System.Collections.Generic;
using System.IO;

namespace UserLoginNEW
{
    public static class UserData
    {

        public static List<User> _testUsers = new List<User>();

        public static List<User> TestUsers
        {
            get
            {
                if (_testUsers.Count < 1)
                {
                    ResetTestUserData();         
                }
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData() {
                _testUsers.Add(new User
                {
                    Username = "Hristo",
                    Password = "12345678",
                    FacNumber = "121217091",
                    Role = 1,
                    Created = DateTime.Now,
                    DateValid = DateTime.MaxValue
                });

                _testUsers.Add(new User {
                    Username = "Ivan",
                    Password = "87654321",
                    FacNumber = "121217062",
                    Role = 4,
                    Created = DateTime.Now,
                    DateValid = DateTime.MaxValue

                });

                _testUsers.Add(new User {
                    Username = "Peter",
                    Password = "0000000000",
                    FacNumber = "121217888",
                    Role = 4,
                    Created = DateTime.Now,
                    DateValid = new DateTime(2008, 6, 5)
                });
        }

        public static User IsUserPassCorrect(string Username, string Password) {
            //UserInfoContext context = new UserInfoContext();
            foreach (User u in TestUsers) {
                if (Username == u.Username && Password == u.Password)
                    return u;
            }
            /*User result = (from us in context.Users
                           where Username == us.Username
                           && Password == us.Password
                 select us).First();
            return result;   */  
            return null;
        }

        public static void SetUserActivityTo(string username, DateTime newDateValid) {
            foreach (User u in TestUsers) {
                
                if (username == u.Username){
                    u.DateValid = newDateValid;
                    //Console.WriteLine(u.DateValid);
                    //Console.WriteLine(u.Username);
                    Logger.LogActivity("Changing date valid on " + username);
                }
            }
        }

        public static void AssignUserRole(string username, UserRoles newRole) {
            foreach (User u in TestUsers) {
                if (username == u.Username){ 
                    u.Role = Convert.ToInt32(newRole);
                    Console.WriteLine("New role:" + (UserRoles)u.Role);
                    Logger.LogActivity("Changing role on " + username);
                }
            }
            /*UserInfoContext context = new UserInfoContext();
            User user = (from u in TestUsers
                         where username == u.Username
                         select u).First();
            user.Role = Convert.ToInt32(newRole);
            context.SaveChanges();
            Logger.LogActivity("Changing role on " + username); */
        }

        
    }
}
