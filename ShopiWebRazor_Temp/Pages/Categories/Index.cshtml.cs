using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiWebRazor_Temp.Data;
using ShopiWebRazor_Temp.Models;

namespace ShopiWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext_Razor dbContext_Razor;

        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext_Razor dbContext_Razor)
        {
            this.dbContext_Razor = dbContext_Razor;
        }

        public void OnGet()
        {
            CategoryList = dbContext_Razor.Categories.ToList();
        }
    }
}
