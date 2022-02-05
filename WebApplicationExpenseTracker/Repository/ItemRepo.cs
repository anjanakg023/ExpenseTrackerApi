using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;
using WebApplicationExpenseTracker.ViewModel;

namespace WebApplicationExpenseTracker.Repository
{
    public class ItemRepo : IItemRepo
    {
        private readonly ExpenseTrackerDBContext _context;

        public ItemRepo(ExpenseTrackerDBContext context)
        {
            _context = context;
        }


        //get all items
        #region Get Items
        public async Task<List<Items>> GetAllItems()
        {
            if (_context != null)
            {                             
                return await _context.Items.ToListAsync();
            }
            return null;
        }
        #endregion


        //add new items
        #region add new item
        public async Task<ActionResult<Items>> AddItems(Items items)
        {
            if (_context != null)
            {

                await _context.Items.AddAsync(items);
                await _context.SaveChangesAsync();
                return items;
            }
            return null;


        }
        #endregion


        //update an item
        #region update item
        public async Task UpdateItem(Items items)
        {
            if (_context != null)
            {
                _context.Entry(items).State = EntityState.Modified;
                _context.Items.Update(items);
                await _context.SaveChangesAsync();  //commit the transaction
            }
        }
        #endregion


        //delete an item
        #region delete an item
        public  async Task<int> DeleteItem(int? id)
        { 
            //declare variable
            int result = 0;
            if (_context != null)
            {                                                                //linq
                var itm = await _context.Items.FirstOrDefaultAsync(item => item.ItemId == id);

                //check condition
                if (itm != null)
                {
                    //delete
                    _context.Items.Remove(itm);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        } 
        #endregion


        //list of items
         public async Task<List<ItemViewModel>> GetItems()
        {
            if (_context!= null)
            {
                //LINQ

                return await(
                    from i in _context.Items
                    from c in _context.Categories
                    where i.CategoryId == c.CategoryId
                    orderby i.Itemcost descending
                    select new ItemViewModel
                    {
                        ItemId = i.ItemId,
                        Itemname = i.Itemname,
                        Categoryname =c.Categoryname,
                        Itemcost=i.Itemcost
        
                    }).ToListAsync();
            }
            return null;
    }

         






    }
}
