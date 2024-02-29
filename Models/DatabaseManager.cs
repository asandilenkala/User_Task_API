using System;
using Microsoft.EntityFrameworkCore;

namespace User_Task_API.Models
{
	//this class/model communicate with the database 
	public class DatabaseManager : DbContext
	{
		public DatabaseManager(DbContextOptions options) : base(options)
		{

		}

		public DbSet<User> users { get; set; }
		public DbSet<Task> tasks { get; set; }

	}
}

