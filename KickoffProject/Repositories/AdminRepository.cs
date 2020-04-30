using KickoffProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickoffProject.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminProjectContext _context;
        public AdminRepository(AdminProjectContext context)
        {
            _context = context;
        }
        public void AddCategory(Category obj)
        {
            _context.Add(obj);
            _context.SaveChanges();



        }

        public void AddSubcategory(SubCategory obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void DeletCategory(int cid)
        {
            Category c = _context.Category.Find(cid);
            _context.Remove(c);
            _context.SaveChanges();
        }


        public void DeletSubCategory(int subid)
        {
            SubCategory c = _context.SubCategory.Find(subid);
            _context.Remove(c);
            _context.SaveChanges();

        }

        public List<Category> GetAllItems()
        {
            List<Category> c = _context.Category.ToList();
            return c;

        }

        public List<SubCategory> GetAllSubcategories()
        {
            List<SubCategory> c = _context.SubCategory.ToList();
            return c;
        }

        public Category getCategoryid(int cid)
        {
            return _context.Category.Find(cid);

        }

        public SubCategory getsubcategorybyid(int subid)
        {
            return _context.SubCategory.Find(subid);

        }

        public void updatecategory(Category obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public void updatesubcategory(SubCategory obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
