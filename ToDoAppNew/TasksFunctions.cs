using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace ToDoAppNew
{
    public class TasksFunctions
    {
        public static string title;
        public static string description;
        public static string dueDate;
        public static string priorityLevel;
        public static string newPriority;
        public static string completed;


        public static bool choice = true;
        public static bool entry = true;

        public static List<ToDoItem> toDoItems = new List<ToDoItem>();


        public static void AddTask()
        {
            ToDoItem toDoItem = new ToDoItem();

            Header.Heading("ADD TASK ToDos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();

            while (true)
            {

                Console.Write("Please enter a task title: ");
                title = Console.ReadLine().Trim();
                bool isTitle = Validation.ValidateTitle(title);

                if (title == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Title field cannot be empty.");
                    Console.ResetColor();
                }
                else if (!isTitle)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid title.");
                    Console.ResetColor();
                }
                else if (title.Length > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Title should be 30 characters or less.");
                    Console.ResetColor();
                }
                else if (title.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Title is too short.");
                    Console.ResetColor();
                }
                else if (toDoItems.Select(x => x.Title).Contains(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Title \"{title}\" Already Exist.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }



            Header.Heading("ADD TASK ToDos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
            while (true)
            {
                Console.Write("Enter the task description: ");
                description = Console.ReadLine().Trim();
                bool isDescription = Validation.ValidateDescription(description);

                if (description == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Description field cannot be empty.");
                    Console.ResetColor();
                }
                else if (!isDescription)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid description.");
                    Console.ResetColor();
                }
                else if (description.Length > 200)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Description should be 30 characters or less.");
                    Console.ResetColor();
                }
                else if (description.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Desscription is too short.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }


            Header.Heading("ADD TASK ToDos");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
            while (true)
            {
                Console.Write("Please enter the due date (DD-MM-YYYY): ");
                dueDate = Console.ReadLine().Trim();
                bool isDueDate = Validation.ValidateDate(dueDate);

                if (dueDate == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Date field cannot be empty.");
                    Console.ResetColor();
                }
                else if (!isDueDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Header.Heading("ADD TASK ToDos");
                Console.ResetColor();

                Console.Write("Please choose the priority level of the task:\n\n");
                Console.WriteLine("1. High");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Low \n");
                Console.Write("Enter Your Choice Here: ");
                if (int.TryParse(Console.ReadLine().Trim(), out int choiceInput))
                {
                    if (choiceInput == 1)
                    {
                        priorityLevel = "High";
                        Console.Clear();
                        break;
                    }
                    else if (choiceInput == 2)
                    {
                        priorityLevel = "Medium";
                        Console.Clear();
                        break;
                    }
                    else if (choiceInput == 3)
                    {
                        priorityLevel = "Low";
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid priority choice. Choose 1, 2 or 3.");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        Console.Clear();
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid priority choice.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
            }

            toDoItem.Title = title;
            toDoItem.Description = description;
            toDoItem.DueDate = dueDate;
            toDoItem.Priority = priorityLevel;
            toDoItem.Completed = "False";
            toDoItem.UserID = LoginRegFunctions.currentUserId;

            toDoItems.Add(toDoItem);


            while (true)
            {
                Header.Heading("ADD TASK ToDos");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Task added successfully!\n\n");
                Console.ResetColor();
                TableView.PrintTaskTable(toDoItems);
                Console.Write("Do you want to add another task?\n\n");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No\n");
                Console.Write("Enter your choice here: ");

                if (int.TryParse(Console.ReadLine().Trim(), out int choiceInput))
                {
                    if (choiceInput == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"New Task Loading...");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        Console.Clear();
                        AddTask();
                    }
                    else if (choiceInput == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task Updated Successfully.");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        Console.Clear();
                        EntryFunctions.UserHome();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid option. Please enter either 1 or 2.");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        Console.Clear();
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid option. Please choose either 1 or 2.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
            }
        }


        public static void EditToDoItem(List<ToDoItem> toDoItems)
        {
            while (true)
            {
                Header.Heading("Edit Task");
                TableView.PrintTaskTable(TasksFunctions.toDoItems);

                Console.Write("Enter the Id of the ToDoItem you want to edit: ");
                string inputId = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(inputId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please enter a valid ID");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
                else if (!int.TryParse(inputId, out int idToEdit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }

                else if (idToEdit < 0 || idToEdit > toDoItems.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID not available on the table.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }

                else
                {
                    ToDoItem toDoItem = toDoItems.Find(item => item.TableId == idToEdit);

                    if (toDoItem != null)
                    {
                        Console.Write("Enter the new Title (Press Enter to keep current value): ");
                        string newTitle = Console.ReadLine().Trim();
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            toDoItem.Title = newTitle;
                        }

                        Console.Write("Enter the new Description (Press Enter to keep current value): ");
                        string newDescription = Console.ReadLine().Trim();
                        if (!string.IsNullOrEmpty(newDescription))
                        {
                            toDoItem.Description = newDescription;
                        }
                        while (true)


                        {
                            Console.Write("Enter the new date (DD-MM-YYYY)[Press Enter to keep current value]: ");
                            string newDueDate = Console.ReadLine().Trim();
                            bool isNewDueDate = Validation.ValidateDate(newDueDate);

                            if (newDueDate == "")
                            {
                                break;
                            }
                            else if (!isNewDueDate)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid date.");
                                Console.ResetColor();
                            }
                            else if (!string.IsNullOrEmpty(newDueDate))
                            {
                                toDoItem.DueDate = Convert.ToString(newDueDate);
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write("\nSelect the new priority level (Press Enter to keep current value): \n\n");
                            Console.WriteLine("1. High");
                            Console.WriteLine("2. Medium");
                            Console.WriteLine("3. Low \n");
                            Console.Write("Enter Your Choice Here: ");
                            string inputChoice = Console.ReadLine().Trim();
                            if (inputChoice == "")
                            {
                                break;
                            }
                            if (int.TryParse(inputChoice, out int choiceInput))
                            {
                                if (choiceInput == 1)
                                {
                                    newPriority = "High";
                                    toDoItem.Priority = newPriority;
                                    break;
                                }
                                else if (choiceInput == 2)
                                {
                                    newPriority = "Medium";
                                    toDoItem.Priority = newPriority;
                                    break;
                                }
                                else if (choiceInput == 3)
                                {
                                    newPriority = "Low";
                                    toDoItem.Priority = newPriority;
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Invalid new priority choice. Choose 1, 2 or 3.");
                                    Thread.Sleep(2000);
                                    Console.ResetColor();
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Invalid priority choice.");
                                Thread.Sleep(2000);
                                Console.ResetColor();
                                Console.Clear();
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ToDoItem updated successfully!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"ToDoItem with Id {idToEdit} not found.");
                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                    EntryFunctions.UserHome();
                }
            }
        }



        public static void DeleteTask(List<ToDoItem> toDoItems)
        {
            while (true)
            {
                Header.Heading("Delete Task");
                TableView.PrintTaskTable(TasksFunctions.toDoItems);
                Console.Write("Enter the Id of the item you want to delete: ");
                string inputID = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(inputID))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please enter a valid ID");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
                else if (!int.TryParse(inputID, out int idToDelete))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }

                else if (idToDelete < 0 || idToDelete > toDoItems.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID not available on the table.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
                else
                {

                    ToDoItem itemToDelete = toDoItems.FirstOrDefault(item => item.TableId == idToDelete);

                    if (itemToDelete != null)
                    {
                        toDoItems.Remove(itemToDelete);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Item deleted successfully!");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        Console.Clear();
                        EntryFunctions.UserHome();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Item not found.");
                        Console.ResetColor();
                    }

                    Thread.Sleep(1500);
                    Console.Clear();
                    EntryFunctions.UserHome();
                }
            }
        }

        public static void CompleteToDoItem(List<ToDoItem> toDoItems)
        {
            while (true)
            {
                Header.Heading("Set task to completed.");
                TableView.PrintTaskTable(TasksFunctions.toDoItems);

                Console.Write("Enter the ID of the to-do item you want to mark as completed: ");
                string inputID = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(inputID))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please enter a valid ID");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }

                else if (!int.TryParse(inputID, out int id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }

                else if (id < 0 || id > toDoItems.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID not available on the table.");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                }
                else
                {
                    ToDoItem item = toDoItems.FirstOrDefault(i => i.TableId == id);

                    if (item == null)
                    {
                        Console.WriteLine($"No to-do item found with ID {id}");
                        break;
                    }
                    else
                    {
                        item.Completed = "True";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Item has been successfully set to completed!");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        Console.Clear();
                        EntryFunctions.UserHome();
                    }
                }
            }
        }



    }
}
