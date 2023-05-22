using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ToDoAppNew
{
    public class Validation
    {

        public static bool ValidateUserName(string str)
        {
            string pattern = (@"^[a-zA-Z][a-zA-Z0-9_]*$");

            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public static bool ValidateEmail(string str)
        {
            string pattern = (@"^[a-zA-Z][a-zA-Z0-9._%+-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");


            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePassword(string str)
        {
            string pattern = (@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\d\s]).{8,}$");



            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool ValidateTitle(string str)
        {
            string pattern = (@"^[a-zA-Z0-9\s]+$");

            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool ValidateDescription(string str)
        {
            string pattern = (@"^[A-Za-z0-9\s\p{P}]+$");

            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool ValidateString(string str)
        {
            string pattern = (@"^[a-zA-Z]+$");

            if (Regex.IsMatch(str, pattern))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool ValidateDate(string input)
        {

            DateTime date;

            if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (date < DateTime.Today)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

    }
}
