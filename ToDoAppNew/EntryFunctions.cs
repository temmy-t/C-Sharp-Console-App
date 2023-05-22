using System;



namespace ToDoAppNew
{
    public class EntryFunctions
    {
        public static string title;
        public static string description;
        public static string dueDate;
        public static string priorityLevel;
        public static string completed;


        public static bool choice = true;
        public static bool entry = true;
        /// <summary>
        /// The app starts from here
        /// </summary>
        public static void AppStart()
        {


            while (entry)
            {
                Header.Heading("TopzyTech ToDo App");

                Console.WriteLine($"Welcome! Please choose an option. \n ");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit \n");

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
                            AskChoiceAgain();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Option {choiceInput} Not Available. Please Choose Between 1 And 2.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        AskChoiceAgain();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please choose between 1 And 2.");
                        Console.ResetColor();
                    }

                }
            }
        }





       public static void UserHome()

        {
            while (entry)
            {
                Header.Heading($"{LoginRegFunctions.currentUserName.ToUpper()}'s ToDos");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You are logged in, {LoginRegFunctions.currentUserName}.");
                Console.ResetColor();

                Console.WriteLine($"\nPlease choose an option. \n ");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View all Tasks");
                Console.WriteLine("3. Edit Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Complete Task");
                Console.WriteLine("6. Logout \n");


                while (choice)
                {
                    Console.Write("Enter Your Choice Here: ");

                    if (int.TryParse(Console.ReadLine().Trim(), out int choiceInput))
                    {
                        if (choiceInput == 1)
                        {
                            Console.Clear();
                            TasksFunctions.AddTask();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 2)
                        {
                            Console.Clear();
                            TableView.PrintTaskTable(TasksFunctions.toDoItems);
                            TaskVIewAppend();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 3)
                        {
                            Console.Clear();
                            TasksFunctions.EditToDoItem(TasksFunctions.toDoItems);
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 4)
                        {
                            Console.Clear();
                            TasksFunctions.DeleteTask(TasksFunctions.toDoItems);
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 5)
                        {
                            Console.Clear();
                            TasksFunctions.CompleteToDoItem(TasksFunctions.toDoItems);
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 6)
                        {
                            LoginRegFunctions.currentUserId = Guid.Empty;
                            LoginRegFunctions.currentUserName = null;
                            Console.Clear();
                            AppStart();
                            choice = false;
                            entry = false;
                        }
                        else
                        {
                            AskTaskChoiceAgain();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Option {choiceInput} Not Available. Please Choose from option 1 And 6.");
                            Console.ResetColor();
                        }

                    }

                    else
                    {
                        AskTaskChoiceAgain();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please choose from option 1 And 6.");
                        Console.ResetColor();
                      
                    }

                }
            }
        }



        public static void TaskVIewAppend()

        {
            while (entry)
            {
                Console.WriteLine($"\nWhat do you want to do next?\n ");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View all Tasks");
                Console.WriteLine("3. Edit Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Complete Task");
                Console.WriteLine("6. Logout \n");


                while (choice)
                {
                    Console.Write("Enter Your Choice Here: ");

                    if (int.TryParse(Console.ReadLine().Trim(), out int choiceInput))
                    {
                        if (choiceInput == 1)
                        {
                            Console.Clear();
                            TasksFunctions.AddTask();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 2)
                        {
                            Console.Clear();
                            TableView.PrintTaskTable(TasksFunctions.toDoItems);
                            UserHome();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 3)
                        {
                            Console.Clear();
                            TasksFunctions.EditToDoItem(TasksFunctions.toDoItems);
                            UserHome();
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 4)
                        {
                            Console.Clear();
                            TasksFunctions.DeleteTask(TasksFunctions.toDoItems);
                            UserHome() ;
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 5)
                        {
                            Console.Clear();
                            TasksFunctions.CompleteToDoItem(TasksFunctions.toDoItems);
                            choice = false;
                            entry = false;
                        }
                        else if (choiceInput == 6)
                        {
                            LoginRegFunctions.currentUserId = Guid.Empty;
                            Console.Clear();
                            AppStart();
                            choice = false;
                            entry = false;
                        }
                        else
                        {
                            AskTaskChoiceAgain();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Option {choiceInput} Not Available. Please Choose from option 1 And 6.");
                            Console.ResetColor();
                        }

                    }

                    else
                    {
                        AskTaskChoiceAgain();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please choose from option 1 And 6.");
                        Console.ResetColor();

                    }

                }
            }
        }



        static void AskChoiceAgain()
        {
            Console.Clear();
            entry = true;
            choice = true;
            Header.Heading("ToDo App");
            Console.WriteLine($"Welcome! Please choose an option. \n ");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit \n");
        }


        static void AskTaskChoiceAgain()
        {
            Console.Clear();
            entry = true;
            choice = true;
            Header.Heading($"{LoginRegFunctions.userName.ToUpper()}'s ToDos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome {LoginRegFunctions.currentUserName}.");
            Console.ResetColor();

            Console.WriteLine($"Welcome! Please choose an option. \n ");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View all Tasks");
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Complete Task");
            Console.WriteLine("6. Logout \n");
        }



    }
}
