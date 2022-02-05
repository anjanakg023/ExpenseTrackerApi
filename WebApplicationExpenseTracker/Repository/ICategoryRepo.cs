using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;

namespace WebApplicationExpenseTracker.Repository
{
    public interface ICategoryRepo
    {
        //getall categories
        Task<List<Categories>> GetAllCategories();

        // Add Users
        Task<int> AddCategory(Categories category);

        // Update user
        Task UpdateCategory(Categories category);

        //delete a category
        Task<int> DeleteCategoryById(int? id);

        //  USING VIEW MODEL

        //Task<Category> GetCategorybyId(int id)
    }
}
