using System;
namespace User_Task_API.Models
{
    //class for updating user data
	public class UpdateUser
	{
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

