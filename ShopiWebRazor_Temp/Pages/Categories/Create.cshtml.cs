using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiWebRazor_Temp.Data;
using ShopiWebRazor_Temp.Models;

namespace ShopiWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext_Razor dbContext_Razor;

        public CreateModel(ApplicationDbContext_Razor dbContext_Razor)
        {
            this.dbContext_Razor = dbContext_Razor;
        }

        [BindProperty]
        public Category categories { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            dbContext_Razor.Categories.Add(categories);
            dbContext_Razor.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
