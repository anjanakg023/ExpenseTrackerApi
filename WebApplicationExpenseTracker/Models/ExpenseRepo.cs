using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.ViewModel;

namespace WebApplicationExpenseTracker.Models
{
    public class ExpenseRepo : IExpenseRepo
    {
        private readonly ExpenseTrackerDBContext _context;
        public ExpenseRepo(ExpenseTrackerDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddExpense(Expenses expense)
        {
            if (_context != null)
            {
                await _context.Expenses.AddAsync(expense);
                await _context.SaveChangesAsync();
                return expense.Expenseid;
            }
            return 0;
        }

        public  async Task<List<ExpenseViewModel>> GetAllExpenses()
        {
            if (_context != null)
            {
                //LINQ

                return await(
                    from i in _context.Items
                    from c in _context.Categories
                    from e in _context.Expenses
                    where i.CategoryId == c.CategoryId
                    orderby e.Expensedate 
                    select new ExpenseViewModel
                    {
                        Itemname = i.Itemname,
                        Categoryname = c.Categoryname,
                        Expensedate =e.Expensedate,
                        Expenseid=e.Expenseid,
                        month=e.Expensedate.Value.ToString("MMMM"),

                    }).ToListAsync();
            }
            return null;
        }

        //public  async Task<int> DeleteExpenseByID(int? id)
        //{
        //    if (_context != null)
        //    {
        //        var expenses = await _context.Expenses.FirstOrDefaultAsync(exp => exp.Expenseid == id);
        //        if (expenses != null)
        //        {
        //            _context.Expenses.Remove(expenses);

        //            return await _context.SaveChangesAsync();
        //        }
        //        return 0;

        //    }
        //    return 0;
        //}



        public async Task<List<Expenses>> GetExpenses()
        {
            if (_context != null)
            {
                return await _context.Expenses.ToListAsync();
            }
            return null;
        }

        public async Task UpdateExpense(Expenses expense)
        {
            if (_context != null)
            {
                _context.Entry(expense).State = EntityState.Modified;
                _context.Expenses.Update(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}
