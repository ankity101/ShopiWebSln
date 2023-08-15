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
                if(category.Name.ToLower() == "test")
                {
                    ModelState.AddModelError("", "Test Is an Invalid Value");
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


        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category? category)
        {
            if(category.Id==null || category.Id==0)
            {
                return View();
            }
            dbContext.Categories.Update(category);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
           Category category =  dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            
            try
            {
                if(category==null)
                {
                    return View("Index");
                }
                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception("Error Deleting Category,Please Contact ");
            }
        }

    }
}
