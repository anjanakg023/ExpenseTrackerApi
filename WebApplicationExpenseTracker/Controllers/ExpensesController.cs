using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;
using WebApplicationExpenseTracker.ViewModel;

namespace WebApplicationExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepo _expense;

        public ExpensesController(IExpenseRepo expenses)
        {
            _expense = expenses;
        }



        #region Get all Expense
        [HttpGet]
        public async Task<List<Expenses>> GetExpenses()
        {
            return await _expense.GetExpenses();
        }
        #endregion

        #region Get all Expense
        [HttpGet]
        [Route("Getexpenses")]
        public async Task<List<ExpenseViewModel>> GetAllExpenses()
        {
            return await _expense.GetAllExpenses();
        }
        #endregion

        #region Add Expense
        [HttpPost]
        [Authorize]
        public async Task<int> AddExpense(Expenses expense)
        {
            return await _expense.AddExpense(expense);
        }
        #endregion

        #region Update  Expense
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateExpense(Expenses expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _expense.UpdateExpense(expense);
                    return Ok(expense);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        ////delete an expense
        //#region delete an expense
        //[HttpDelete("{id}")]
        //public async Task<int> DeleteExpensesById(int? id)
        //{

        //    int result = 0;
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        result = await _expense.DeleteExpenseByID(id);
        //        if (result == 0)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(); //retrun ok(employee)
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion
    }


}
