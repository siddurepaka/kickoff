using KickoffProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickoffProject.Repositories
{
  public  interface IAdminRepository
    {
        List<Category> GetAllItems();
        List<SubCategory> GetAllSubcategories();
        void AddCategory(Category obj);
        void AddSubcategory(SubCategory obj);
        Category getCategoryid(int cid);
        SubCategory getsubcategorybyid(int subid);
        void DeletCategory(int cid);
        void DeletSubCategory(int subid);
        void updatecategory(Category obj);
        void updatesubcategory(SubCategory obj);

    }
}
