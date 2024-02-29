using System;
namespace User_Task_API.Models
{
    //class to add tasks
    public class AddTask
    {
        public string Title { get; set; }
        public string UserID { get; set; }
        public string DueDate { get; set; }
        public string Description { get; set; }
    }
}

