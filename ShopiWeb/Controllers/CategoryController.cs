using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopiWeb.Data;
using ShopiWeb.Models.Models;
using System.Reflection.Metadata.Ecma335;

namespace ShopiWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {

            List<Category>objCategoryList =  dbContext.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category category)
        {
            try
            {
                if(category.Name == category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Display Order And Name Can't Be Same");
                }
                if (ModelState.IsValid)
                {
                    dbContext.Add(category);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding Category");
            }
        }
    }
}
