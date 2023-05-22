using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppNew
{
    public class Header
    {
        public static void Heading(string headerText)
        {
            char headerChar = '*';
            int headerWidth = 92;

            Console.WriteLine(new string(headerChar, headerWidth));

            Console.WriteLine(new string(' ', (headerWidth - headerText.Length) / 2) + headerText);
            Console.WriteLine(new string(headerChar, headerWidth));
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
