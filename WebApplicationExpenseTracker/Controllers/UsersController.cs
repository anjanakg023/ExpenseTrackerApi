using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;
using WebApplicationExpenseTracker.Repository;

namespace WebApplicationExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        //get all users
        #region get
        [HttpGet]
        public async Task<List<Users>> GetAllCategories()
        {
            return await _userRepo.GetUsers();
        }
        #endregion

        //add an user
        #region Add a user
        [HttpPost]
        public async Task<ActionResult<Users>> AddItem(Users user)
        {
            return await _userRepo.AddUser(user);
        }
        #endregion


        //update an item
        #region Update item
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepo.UpdateUser(user);
                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        //delete an item
        #region Delete  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _userRepo.DeleteUserByID(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(); //retrun ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //search user by id
        #region get by id
        [HttpGet("{id}")]

        public async Task<ActionResult<Users>> GetUserByID(int? id)
        {
            
            try
            {
                var itemOne = await _userRepo.GetUserByID(id);
                if (itemOne == null)
                {
                    return NotFound();
                }
                return itemOne;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
