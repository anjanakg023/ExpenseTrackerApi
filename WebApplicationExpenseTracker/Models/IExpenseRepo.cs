using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.ViewModel;

namespace WebApplicationExpenseTracker.Models
{
   public interface IExpenseRepo
    {

        Task<List<Expenses>> GetExpenses();
        Task<List<ExpenseViewModel>> GetAllExpenses();


        Task<int> AddExpense(Expenses expense);

        Task UpdateExpense(Expenses expense);

        //Task<int> DeleteExpenseByID(int? id);
    }
}
