using System;
using System.Collections.Generic;

namespace ToDoAppNew
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }     
        public string Password { get; set; }
        public List<ToDoItem> ToDoItem { get; set; } = new List<ToDoItem>();
    }
}
