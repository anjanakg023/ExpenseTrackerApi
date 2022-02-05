using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
   public interface IItemListRepo
    {
        //get itemlists
        Task<List<ItemList>> GetItemLists();

        //add an itemList
        Task<ActionResult<ItemList>> AddItemList(ItemList item);

        //update an itemlist
        Task UpdateItemList(ItemList item);
    }
}
