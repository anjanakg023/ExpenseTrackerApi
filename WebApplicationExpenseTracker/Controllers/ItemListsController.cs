﻿using Microsoft.AspNetCore.Http;
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
    public class ItemListsController : ControllerBase
    {
        private readonly IItemListRepo _itemRepo;
        public ItemListsController(IItemListRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        //get itemlists
        [HttpGet]
        public async Task<List<ItemList>> GetItemLists()
        {
            return await _itemRepo.GetItemLists();
        }

        //add new itemlist
        #region Add list
        [HttpPost]
        public async Task<ActionResult<ItemList>> AddItemList(ItemList item)
        {
            return await _itemRepo.AddItemList(item);
        }
        #endregion


        //update a itemList
        #region update an item
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] ItemList item)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _itemRepo.UpdateItemList(item);
                    return Ok(item);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
