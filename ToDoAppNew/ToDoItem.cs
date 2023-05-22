using System;


namespace ToDoAppNew
{
    public class ToDoItem
    {
        public int TableId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate {get; set; }
        public string Priority { get; set; }
        public string Completed {get; set; }
        public Guid UserID { get; set; }

    }
}
