using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public class Program
    {
        static public void FunctionOnError(string s) {
            Console.WriteLine("!!!" + s + "!!!");
            
        }

        static void Main(string[] args)
        {
            //User admin = new User();
            //Console.WriteLine(admin.name + " " + admin.Role + " " + admin.password + " " + admin.FacNumber + "  Ot User");
            string usernameFromRead, passFromRead;
            Console.WriteLine("Insert username and password");
            Console.Write("Enter Username: ");
            usernameFromRead = Console.ReadLine();
            Console.Write("Enter Password: ");
            passFromRead = Console.ReadLine();
            LoginValidation log = new LoginValidation(usernameFromRead, passFromRead, FunctionOnError);
            User user = null;
            if (log.ValidateUserInput(ref user))
            {
                //Console.WriteLine(UserData.TestUser.name + " " + UserData.TestUser.Role + " "
                //                + UserData.TestUser.password + " " + UserData.TestUser.FacNumber + "  Ot UserData");
                Console.WriteLine("Username: " + user.Username + "\nPassword: " + user.Password +
                                  "\nRole: " + user.Role + "\nFacNumber: " + user.FacNumber +
                                  "\nCreated on: " + user.Created + "\nValid to: " + user.DateValid);
                Console.WriteLine(LoginValidation.CurrentUserRole);
                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("This person is an Administrator");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("This person is an Anonymous");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("This person is a Inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("This person is a Professor");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("This person is a Student");
                        break;
                    default:
                        Console.WriteLine("Wrong role");
                        break;
                }
                if(LoginValidation.CurrentUserRole == UserRoles.ADMIN) 
                {
                    ShortMenu();
                }
                
            }
        }

        static public void ShortMenu() {
            Console.WriteLine("\nChoose option:" + "\n0: Exit" + "\n1: Change user's role" + "\n2: Change user's date valid" +
                              "\n3: List of all users" + "\n4: Check log file" + "\n5: Check current activity");
            string name;
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i) {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("\nInsert name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Insert new role: ");
                    UserRoles newUserRole = (UserRoles)Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(name, newUserRole);
                    break;
                case 2:
                    Console.WriteLine("\nInsert name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Insert new date: ");
                    DateTime newDateValid = Convert.ToDateTime(Console.ReadLine());
                    UserData.SetUserActivityTo(name, newDateValid);
                    break;
                case 3:
                    break;
                case 4:
                    StreamReader sr = new StreamReader("test.txt");
                    StringBuilder line = new StringBuilder();
                    line.Append(sr.ReadToEnd());
                    Console.WriteLine(line.ToString());
                    sr.Close();
                    break;
                case 5:
                    Logger.GetCurrentSessionActivities();
                    break;
            }
        }
    }
}
