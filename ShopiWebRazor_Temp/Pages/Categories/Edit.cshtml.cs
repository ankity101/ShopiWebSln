using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiWebRazor_Temp.Data;
using ShopiWebRazor_Temp.Models;

namespace ShopiWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext_Razor dbContext_Razor;
        public EditModel(ApplicationDbContext_Razor dbContext_Razor)
        {
            this.dbContext_Razor = dbContext_Razor;
        }

        [BindProperty]
        public Category category { get; set; }
        public void OnGet(int? id)
        {
            if(id!=null && id!=0)
             category = dbContext_Razor.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext_Razor.Categories.Update(category);
                dbContext_Razor.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
