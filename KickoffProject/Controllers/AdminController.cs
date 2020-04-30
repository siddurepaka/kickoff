using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KickoffProject.Models;
using KickoffProject.Repositories;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminRepository _repo;
        private readonly ILogger<AdminController> _logger;


        public AdminController(IAdminRepository repo, ILogger<AdminController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpPost]
        [Route("AddCategory")]
        public void Addcategory(Category obj)
        {
            _repo.AddCategory(obj);

        }
        [HttpPost]
        [Route("AddSubCategory")]
        public void Addsubcategory(SubCategory obj)
        {
            _repo.AddSubcategory(obj);

        }
        [HttpGet]
        [Route("getcategory/{cid}")]
        public IActionResult getcategory(int cid)
        {
            _logger.LogInformation("fetching categories by id");
            return Ok(_repo.getCategoryid(cid));

            ;
        }
        [HttpGet]
        [Route("getsubcategory/{subid}")]
        public IActionResult getsubcategory(int subid)
        {
            _logger.LogInformation("fetching   subcategories by id: ");
            return Ok(_repo.getsubcategorybyid(subid));
            throw new Exception("Exception while fetching  subcategories by given id  from the storage.");
        }
        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult Get()
        {
            _logger.LogInformation("fetching  all categories");
            var cat = _repo.GetAllItems();
            _logger.LogInformation($"Returning {cat.Count} categories.");
            return Ok(cat);
            throw new Exception("Exception while fetching all the categories from the storage.");


        }
        [HttpGet]
        [Route("GetAllSubcategory")]
        public IActionResult GetSubcategories()
        {

            _logger.LogInformation("fetching  all subcategories");
            var cat = _repo.GetAllSubcategories();
            return Ok(cat);
            throw new Exception("Exception while fetching all the subcategories from the storage.");

        }
        [HttpDelete]
        [Route("DeleteCategory/{cid}")]
        public void DeleteCategory(int cid)
        {
            _repo.DeletCategory(cid);
        }






        [HttpDelete]
        [Route("DeleteSubCategory/{subid}")]
        public void DeleteSubCategory(int subid)
        {
            _repo.DeletSubCategory(subid);


        }


        [HttpPut]
        [Route("updatecategory")]
        public IActionResult updatecategory(Category obj)
        {

            _repo.updatecategory(obj);
            return Ok();

        }
        [HttpPut]
        [Route("updatesubcategory")]
        public IActionResult updatesubcategory(SubCategory obj)
        {

            _repo.updatesubcategory(obj);
            return Ok();




        }

    }
}
