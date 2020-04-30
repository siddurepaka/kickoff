using KickoffProject.Models;
using KickoffProject.Repositories;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    class TestAdminService
    {
        AdminRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new AdminRepository(new AdminProjectContext());

        }
        [Test]
        [Description("to Add category")]
        public void TestAddCategory()
        {
            _repo.AddCategory(new Category()
            {
                Cid = 3,
                Cname = "Kids",
                Cdetails = "products"

            });
            var result = _repo.getCategoryid(3);
            Assert.IsNotNull(result);

        }
        [Test]
        [Description("to Add subcategory")]
        public void TestAddSubCategory()
        {
            _repo.AddSubcategory(new SubCategory()
            {
                Subid = 4,
                Cid = 1,
                Subname = "Kids",
               Sdetails = "products",
                Gst = 10

            });
            var result = _repo.getsubcategorybyid(4);
            Assert.NotNull(result);

        }
        [Test]
        public void TestGetAllCategory()
        {
            var result = _repo.GetAllItems();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 0);
        }
        [Test]
        public void TestGetAllSubCategory()
        {
            var result = _repo.GetAllSubcategories();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 0);
        }
        [Test]
        public void TestGetCategorybyid()
        {
            var result = _repo.getCategoryid(1);
            Assert.NotNull(result);

        }
        [Test]
        public void TestGetSubCategorybyid()
        {
            var result = _repo.getsubcategorybyid(2);
            Assert.NotNull(result);

        }
        [Test]
        [Description("to test Delete Category")]
        public void TestDeleteCategory()
        {
            _repo.DeletCategory(2);
           var x = _repo.getCategoryid(2);
            Assert.Null(x);
        }
        [Test]
        [Description("to test Delete Subcategory")]
        public void TestDeleteSubCategory()
        {
            _repo.DeletSubCategory(1);
            var x = _repo.getsubcategorybyid(1);
            Assert.Null(x);
        }
        [Test]
        [Description("to test update category")]
        public void TestUpdateCategory()
        {
            Category i = _repo.getCategoryid(1);
            i.Cdetails = "products";
            _repo.updatecategory(i);
            Category i1 = _repo.getCategoryid(1);
            Assert.AreSame(i, i1);

        }
        [Test]
        [Description("to test update subcategory")]
        public void TestUpdateSubCategory()
        {
            SubCategory i = _repo.getsubcategorybyid(2);
            i.Sdetails = "products";
            _repo.updatesubcategory(i);
            SubCategory i1 = _repo.getsubcategorybyid(2);
            Assert.AreSame(i, i1);

        }
    }
}