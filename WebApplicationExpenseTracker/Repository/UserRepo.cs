using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
    public class UserRepo:IUserRepo
    {
        private readonly ExpenseTrackerDBContext _context;

        
        public UserRepo(ExpenseTrackerDBContext context)
        {
            _context = context;
        }

        

        public async Task<ActionResult<Users>> AddUser(Users user)
        {
            if (_context != null)
            {

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;

        }

        public  async Task<int> DeleteUserByID(int? id)
        {
            if (_context != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(cat => cat.UserId == id);
                if (user != null)
                {
                    _context.Users.Remove(user);

                    return await _context.SaveChangesAsync();
                }
                return 0;

            }
            return 0;
        }

        public async Task<ActionResult<Users>> GetUserByID(int? id)
        {
            if (_context != null)
            {
                var category = await _context.Users.FindAsync(id);
                return category;
            }
            return null;
        }

        public  async Task<List<Users>> GetUsers()
        {
            if (_context != null)
            {
                var user = await _context.Users.ToListAsync();
                return user;

            }
            return null;
        }

        public async Task UpdateUser(Users user)
        {
            if (_context != null)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();


            }
        }
    }
}
