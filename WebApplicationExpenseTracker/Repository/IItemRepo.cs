using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;
using WebApplicationExpenseTracker.ViewModel;

namespace WebApplicationExpenseTracker.Repository
{
   public interface IItemRepo
    {
        //Get items
        Task<List<Items>> GetAllItems();


        //Add new item
        Task<ActionResult<Items>> AddItems(Items item);

        //update an item
        Task UpdateItem(Items items);


        //Delete an item
        Task<int> DeleteItem(int? id);


        // List of items,cost, expense type in decreasing order of cost.
        Task<List<ItemViewModel>> GetItems();
    }
}
