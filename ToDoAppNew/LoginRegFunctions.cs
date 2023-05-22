using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ToDoAppNew
{
    public class LoginRegFunctions
    {
        public static Guid Id;
        static string name;
        public static string userName;
        static string password;
        static string confirmPassword;
        static string emailAddress;
        public static Guid currentUserId;
        public static string currentUserName;
        static string emailLogin;
        static string passwordLogin;

        static bool choice = true;
        static bool entry = true;

        public static List<User> usersList = new List<User>();
        public static void RegisterUser()
        {
            Id = Guid.NewGuid();
            User user = new User();

            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S REGISTRATION");
            Console.ResetColor();
            while (true)
            {

                Console.Write("Please Enter Your Name (Example: Temitope Olawole): ");
                name = Console.ReadLine().Trim().ToLower();
                bool isName = Validation.ValidateString(name);

                if (name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Name field cannot be empty.");
                    Console.ResetColor();
                }
                else if (name.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Name is too short.");
                    Console.ResetColor();
                }
                else if (name.Length > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Username should be 20 characters or less.");
                    Console.ResetColor();
                }
                else
                {

                    Console.Clear();
                    break;
                }


            }

            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S REGISTRATION");
            Console.ResetColor();
            while (true)
            {

                Console.Write("Please Enter A Username (Example: temmy123_tee): ");
                userName = Console.ReadLine().Trim().ToLower();
                bool isUserName = Validation.ValidateUserName(userName);

                if (userName == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Username field cannot be empty.");
                    Console.ResetColor();
                }
                else if (!isUserName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\"{userName}\" is not valid. Please refer to the format below:\nUsername must start with a letter. \nNumbers can be included.\nIt can only accept undesrscore \"_\" special character.");
                    Console.ResetColor();
                }
                else if (userName.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Username is too short.");
                    Console.ResetColor();
                }
                else if (userName.Length > 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Username should be 20 characters or less.");
                    Console.ResetColor();
                }
                else if (usersList.Select(x => x.UserName).Contains(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Username \"{userName}\" Already Exist.");
                    Console.ResetColor();
                }
                else
                {

                    Console.Clear();
                    break;
                }


            }

            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S REGISTRATION");
            Console.ResetColor();
            while (true)
            {

                Console.Write("Please Enter An Email Address (Example: temmy123@gmail.com): ");
                emailAddress = Console.ReadLine().Trim().ToLower();
                bool isEmail = Validation.ValidateEmail(emailAddress);


                if (emailAddress == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Email field cannot be empty.");
                    Console.ResetColor();
                }
                else if (!isEmail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{emailAddress} is not a valid e-mail address.");
                    Console.ResetColor();
                }
                else if (emailAddress.Length > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Email address is not valid.");
                    Console.ResetColor();
                }
                else if (usersList.Select(x => x.EmailAddress).Contains(emailAddress))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\"{emailAddress}\" Already Exist.");
                    Console.ResetColor();
                }

                else
                {
                    Console.Clear();
                    break;
                }

            }


            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S REGISTRATION");
            Console.ResetColor();
            while (true)
            {

                Console.Write("Please Enter Your Password: ");
                password = ReadPassword().Trim();
                bool isPassword = Validation.ValidatePassword(password);


                if (password == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPassword field cannot be empty.");
                    Console.ResetColor();
                }
                else if (password.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPassword must not be less than 8 characters.");
                    Console.ResetColor();
                }
                else if (!isPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid password.\nMust include at least one capital letter, small letter, number and special character.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S REGISTRATION");
            Console.ResetColor();
            while (true)
            {

                Console.Write("Confirm Your Password: ");
                confirmPassword = ReadPassword().Trim();
                bool isConfirmPassword = Validation.ValidatePassword(confirmPassword);


                if (confirmPassword == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nThis field cannot be empty.");
                    Console.ResetColor();
                }
                else if (confirmPassword.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPassword must not be less than 8 characters.");
                    Console.ResetColor();
                }
                else if (confirmPassword != password)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPassword does not match.");
                    Console.ResetColor();
                }
                else if (confirmPassword == password)
                {
                    Console.Clear();
                    break;
                }

            }

            user.Id = Id;
            user.Name = name;
            user.UserName = userName;
            user.Password = password;
            user.EmailAddress = emailAddress;

            usersList.Add(user);

            currentUserId = usersList.Where(user => user.EmailAddress == emailAddress &&
                            user.Password == password).Select(user => user.Id)
                            .FirstOrDefault();

            currentUserName = usersList.Where(user => user.EmailAddress == emailAddress &&
                           user.Password == password).Select(user => user.UserName)
                           .FirstOrDefault();

            EntryFunctions.UserHome();
        }



        /// <summary>
        /// User Login Function
        /// </summary>
        public static void LoginUser()
        {
            currentUserName = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S LOGIN");
            Console.ResetColor();

            while (true)
            {
                Console.Write("Please enter your registered e-mail: ");
                emailLogin = Console.ReadLine().Trim().ToLower();
                bool isEmailLogin = Validation.ValidateEmail(emailLogin);

                if (emailLogin == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"E-mail field is empty.");
                    Console.ResetColor();
                }
                else if (!isEmailLogin)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"E-mail format is not correct.");
                    Console.ResetColor();
                }
                bool isEmailExist = usersList.Select(x => x.EmailAddress).Contains(emailLogin);
                if (isEmailExist)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Success!");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    RequestToRegister();
                }


                Console.Write("Please enter your registered password: ");
                passwordLogin = ReadPassword().Trim();

                if (passwordLogin == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Password field is empty.");
                    Console.ResetColor();
                }
                bool isPasswordExist = usersList.Select(x => x.Password).Contains(passwordLogin);
                if (isPasswordExist)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\nSuccess!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    break;
                }

                else if (isEmailExist && isPasswordExist)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPassword match not found.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.Clear() ;
                    EntryFunctions.AppStart();
                }
            }

            currentUserId = usersList.Where(user => user.EmailAddress == emailLogin && 
                            user.Password == passwordLogin).Select(user => user.Id)
                            .FirstOrDefault();

            currentUserName = usersList.Where(user => user.EmailAddress == emailLogin &&
                          user.Password == passwordLogin).Select(user => user.UserName)
                          .FirstOrDefault();

            Console.Clear();
            EntryFunctions.UserHome();
        }



        public static void RequestToRegister()
        {
            while (entry)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Header.Heading("USER'S LOGIN");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"E-mail match not found.({emailLogin})");
                Console.ResetColor();

                Console.WriteLine($"This E-mail is not registered.\n ");
                Console.WriteLine("1. Register a new user ");
                Console.WriteLine("2. Re-enter a registered E-mail");
                Console.WriteLine("3. Exit  \n");

                while (choice)
                {
                    Console.Write("Enter Your Choice Here: ");
                    string option = Console.ReadLine().Trim();
                    int choiceInput;

                    if (int.TryParse(option, out choiceInput))
                    {
                        if (choiceInput == 1)
                        {
                            Console.Clear();
                            LoginRegFunctions.RegisterUser();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 2)
                        {
                            Console.Clear();
                            LoginRegFunctions.LoginUser();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 3)
                        {
                            Environment.Exit(0);

                            choice = false;
                            entry = false;
                        }
                        else
                        {
                            AskRequestToRegisterAgain();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Option {choiceInput} not available. Please choose a valid option .");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        AskRequestToRegisterAgain();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please choose a valid option.");
                        Console.ResetColor();
                    }

                }
            }
        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }

        static void AskRequestToRegisterAgain()
        {
            Console.Clear();
            entry = true;
            choice = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Header.Heading("USER'S LOGIN");
            Console.ResetColor();

            Console.WriteLine($"This E-mail is not registered.\n ");
            Console.WriteLine("1. Register a new user ");
            Console.WriteLine("2. Re-enter a registered E-mail");
            Console.WriteLine("3. Exit  \n");
        }

    }
}
