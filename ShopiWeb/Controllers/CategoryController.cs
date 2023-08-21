using Microsoft.AspNetCore.Mvc;
using Shopi.DataAccess.Data;
using Shopi.DataAccess.Repository;
using Shopi.DataAccess.Repository.IRepository;
using Shopi.Models;

namespace ShopiWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {

            List<Category>objCategoryList = categoryRepo.GetAll().ToList();
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
                    categoryRepo.Add(category);
                    categoryRepo.Save();
                    TempData["success"] = "Category Created Successfully";
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
            var category = categoryRepo.Get(u=> u.Id==id);
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
            categoryRepo.Update(category);
            categoryRepo.Save();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            Category category = categoryRepo.Get(u => u.Id == id);
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
                categoryRepo.Remove(category);
                categoryRepo.Save();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception("Error Deleting Category,Please Contact ");
            }
        }

    }
}
