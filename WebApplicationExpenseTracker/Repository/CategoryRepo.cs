using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ExpenseTrackerDBContext _contextone;
        public CategoryRepo(ExpenseTrackerDBContext contextone)
        {
            _contextone = contextone;
        }

        //get categories
        #region get
        public async Task<List<Categories>> GetAllCategories()
        {
            if (_contextone != null)
            {
                var category = await _contextone.Categories.ToListAsync();
                return category;

            }
            return null;

        }
        #endregion

        //add new category
        #region add
        public async Task<int> AddCategory(Categories category)
        {
            if (_contextone != null)
            {
                await _contextone.Categories.AddAsync(category);
                await _contextone.SaveChangesAsync();
                return category.CategoryId;
            }
            return 0;
        }
        #endregion

        //update category
        #region update
        public async Task UpdateCategory(Categories category)
        {
            if (_contextone != null)
            {
                _contextone.Entry(category).State = EntityState.Modified;
                _contextone.Categories.Update(category);
                await _contextone.SaveChangesAsync();


            }
        }
        #endregion

        //delete a category 
        #region delete
        public async Task<int> DeleteCategoryById(int? id)
        {
            if (_contextone != null)
            {
                var category = await _contextone.Categories.FirstOrDefaultAsync(cat => cat.CategoryId == id);
                if (category != null)
                {
                    _contextone.Categories.Remove(category);

                    return await _contextone.SaveChangesAsync();
                }
                return 0;

            }
            return 0;
        }
        #endregion




       

       
    }
}
