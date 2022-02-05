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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _catRepo;
        public CategoriesController(ICategoryRepo catRepo)
        {
            _catRepo = catRepo;
        }


        //get all categories
        #region get
        [HttpGet]
        public async Task<List<Categories>> GetAllCategories()
        {
            return await _catRepo.GetAllCategories();
        }
        #endregion

        //Add new categories
        #region Add
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Categories category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _catRepo.AddCategory(category);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        //update a category
        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Categories category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _catRepo.UpdateCategory(category);
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

        //delete aa category
        #region delete 
        public async Task<IActionResult> DeleteCategoryById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                var employee = await _catRepo.DeleteCategoryById(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
    }
}
