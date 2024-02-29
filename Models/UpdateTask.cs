using System;
namespace User_Task_API.Models
{
    // class for updating tasks data
	public class UpdateTask
	{
        public string Title { get; set; }
        public string UserID { get; set; }
        public string DueDate { get; set; }
        public string Description { get; set; }
    }
}

