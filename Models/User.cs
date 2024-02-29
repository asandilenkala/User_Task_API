using System;
namespace User_Task_API.Models
{
    //model or class for User only
    public class User
	{
		public Guid ID { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; } 
	}
}

