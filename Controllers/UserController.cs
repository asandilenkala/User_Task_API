using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User_Task_API.Models;

// // This class implements controllers and endpoints for CRUD operations for user only

namespace User_Task_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller  //extending Controllers which is imported from Microsoft.AspNetCore.Mvc
    {
        private readonly DatabaseManager dbManager;   //Communicate with in-memory database.
        // GET: /<controller>/
        public UserController(DatabaseManager dbManager)  // Constructure for this task class
        {
            this.dbManager = dbManager;
        }



        [HttpGet]
        [Route("getUser")]
        public IActionResult GetUser()  //method to get/return the usersß
        {
            return Ok(dbManager.users.ToList());
        }


        [HttpGet]
        [Route("{ID:guid}")]
        public IActionResult GetOneUser([FromRoute] Guid ID) //method for user to get data of one user if ID matches
        {
            var userObj = dbManager.users.Find(ID);

            if (userObj != null)
            {
                return Ok(userObj);
            }
            return NotFound();
        }



        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(AddUser addUser)  //method to add user
        {
            User userObj = new User()
            {
                ID = Guid.NewGuid(),
                Username = addUser.Username,
                Email = addUser.Email,
                Password = addUser.Password
            };

            dbManager.users.Add(userObj);
            dbManager.SaveChanges();

            return Ok(userObj);
        }

        [HttpPut]
        [Route("{ID:guid}")]
        public IActionResult UpdateUser([FromRoute] Guid ID, UpdateUser updateUser)  //method for user to update data if ID matches
        {
            var userObj = dbManager.users.Find(ID);

            if (userObj != null)
            {
                userObj.Username = updateUser.Username;
                userObj.Email = updateUser.Email;
                userObj.Password = updateUser.Password;

                dbManager.SaveChanges();
                return Ok(userObj);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{ID:guid}")]
        public IActionResult DeleteUser([FromRoute] Guid ID) //method for user to delete data if ID matches
        {
            var userObj = dbManager.users.Find(ID);

            if (userObj != null)
            {
                dbManager.Remove(userObj);
                dbManager.SaveChanges();
                return Ok(userObj);
            }
            return NotFound();
        }
    }
}

