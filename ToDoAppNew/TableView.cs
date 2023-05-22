using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoAppNew
{
    public class TableView
    {
        static readonly int tableWidth = 90;
 
        public static void PrintTaskTable(List<ToDoItem> toDoItems)
        {
            int tableID = 1;

            Console.Clear();
            Header.Heading($"{LoginRegFunctions.currentUserName.ToUpper()}'s ToDo List");
            PrintLine();
            PrintRow("ID", "TITLE", "DESCRIPTION", "DUE DATE", "PRIORITY", "COMPLETED");
            PrintLine();
            var userToDoItems = (
                                    from item in toDoItems
                                    where item.UserID == LoginRegFunctions.currentUserId
                                    select item
                                ).ToList();
            if (userToDoItems.Count == 0)
            {
                Console.WriteLine("Sorry, your ToDo list is empty.\n\n");
                EntryFunctions.TaskVIewAppend();
            }
            else if (userToDoItems.Count >= 1)
            {
                foreach (ToDoItem item in userToDoItems)
                {
                    PrintRow(Convert.ToString(item.TableId = tableID), item.Title,
                    item.Description, item.DueDate, item.Priority, item.Completed);
                    tableID++;
                }
                PrintLine();
                Console.WriteLine("\n \n");
            }


        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
