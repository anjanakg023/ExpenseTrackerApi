using Microsoft.AspNetCore.Http;
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
    public class ItemsController : ControllerBase
    {
        //data fields
        private readonly IItemRepo _itemRepo;

        //Constructor injection
        public ItemsController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }


        //get all lists
        #region get List
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Items>>> GetAllItems()
        {
            return await _itemRepo.GetAllItems();  
        }
        #endregion



        //add an item
        #region Add an item
        [HttpPost]
        public async Task<ActionResult<Items>> AddItem(Items item)
        {
            return await _itemRepo.AddItems(item);
        }
        #endregion


        //update an item
        #region Update item
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody]Items item)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _itemRepo.UpdateItem(item);
                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        //delete an item
        #region Delete  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _itemRepo.DeleteItem(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(); //retrun ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //list 
        #region GET users
        [HttpGet]
        [Route("Getitems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _itemRepo.GetItems();
                if (items == null)
                {
                    return NotFound();
                }
                return Ok(items);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
