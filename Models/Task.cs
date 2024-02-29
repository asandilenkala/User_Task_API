using System;
namespace User_Task_API.Models
{
    //model or class for Task only
	public class Task
	{
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public string DueDate { get; set; }
    }
}

