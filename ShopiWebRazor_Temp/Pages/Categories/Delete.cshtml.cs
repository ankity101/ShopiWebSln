using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiWebRazor_Temp.Data;
using ShopiWebRazor_Temp.Models;

namespace ShopiWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext_Razor dbContext_Razor;

        public DeleteModel( ApplicationDbContext_Razor dbContext_Razor)
        {
            this.dbContext_Razor = dbContext_Razor;
        }

        [BindProperty]
        public Category category { get; set; }
        public void OnGet(int? id)
        {
            if(id != null)
            category= dbContext_Razor.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            if (category != null)
            {
                dbContext_Razor.Categories.Remove(category);
                dbContext_Razor.SaveChanges();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
