using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
    public class ItemListRepo : IItemListRepo
    {


        private readonly ExpenseTrackerDBContext _context;

        //constructor based dependency injection
        public ItemListRepo(ExpenseTrackerDBContext context)
        {
            _context = context;
        }

       


        //get itemlists
        #region get Itemslists
        public async Task<List<ItemList>> GetItemLists()
        {
            if (_context != null)
            {
                return await _context.ItemList.Include(i=>i.Item).ToListAsync();

            }
            return null;
        }
        #endregion


        //add new item lists
        #region Post itemlist
        public async Task<ActionResult<ItemList>> AddItemList(ItemList item)
        {
            if (_context != null)
            {

                await _context.ItemList.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }



        #endregion


        //update a list
        #region update
        public async Task UpdateItemList(ItemList item)
        {
                if (_context != null)
                {
                    _context.Entry(item).State = EntityState.Modified;
                    _context.ItemList.Update(item);
                    await _context.SaveChangesAsync();
                }
            
        }
        #endregion

    }
}
