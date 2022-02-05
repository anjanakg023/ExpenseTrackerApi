using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
   public interface IUserRepo
    {
        //get all users
        Task<List<Users>> GetUsers();

        //get user by id
        Task<ActionResult<Users>> GetUserByID(int? id);

        //add a user
        Task<ActionResult<Users>> AddUser(Users user);

        //update a user
        Task UpdateUser(Users user);

        //delete a user
        Task<int> DeleteUserByID(int? id);
    }
}
