using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User_Task_API.Models;

// This class implements controllers and endpoints for CRUD operations for tasks only.


namespace User_Task_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : Controller  //extending Controllers which is imported from Microsoft.AspNetCore.Mvc
    {
        private readonly DatabaseManager dbManager;   //Communicate with in-memory database.
        // GET: /<controller>/
        public TaskController(DatabaseManager dbManager)  // Constructure for this task class
        {
            this.dbManager = dbManager;
        }



        [HttpGet]
        [Route("getTask")]
        public IActionResult GetTask()  //method to get/return the tasks
        {
            return Ok(dbManager.tasks.ToList());
        }

        [HttpGet]
        [Route("{ID:guid}")]
        public IActionResult GetOneTask([FromRoute] Guid ID)  //method for task to get data of one user if ID matches
        {
            var taskObj = dbManager.tasks.Find(ID);

            if (taskObj != null)
            {
                return Ok(taskObj);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("addTask")]
        public IActionResult AddTask(AddTask addTask)  //method to add tasks
        {
            Models.Task taskObj = new Models.Task()
            {
                ID = Guid.NewGuid(),
                Title = addTask.Title,
                Description = addTask.Description,
                UserID = addTask.UserID,
                DueDate = addTask.DueDate
            };

            dbManager.tasks.Add(taskObj);
            dbManager.SaveChanges();

            return Ok(taskObj);
        }

        [HttpPut]
        [Route("{ID:guid}")]
        public IActionResult UpdateTask([FromRoute] Guid ID, UpdateTask updateTask) //method for task to update data if ID matches
        {
            var taskObj = dbManager.tasks.Find(ID);

            if (taskObj != null)
            {
                taskObj.Title = updateTask.Title;
                taskObj.UserID = updateTask.UserID;
                taskObj.DueDate = updateTask.DueDate;
                taskObj.Description = updateTask.Description;

                dbManager.SaveChanges();
                return Ok(taskObj);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{ID:guid}")]
        public IActionResult DeleteUser([FromRoute] Guid ID)  //method for task to delete data if ID matches
        {
            var taskObj = dbManager.tasks.Find(ID);

            if (taskObj != null)
            {
                dbManager.Remove(taskObj);
                dbManager.SaveChanges();
                return Ok(taskObj);
            }
            return NotFound();
        }
    }
}
