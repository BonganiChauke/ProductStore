using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Services;
using ProductStore.Models;

namespace ProductStore.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {

        // db context variable
        private readonly ApplicationDbContext _context;

        // product object list
        public List<Product> products { get; set; } = new List<Product>();

        //construstor to request db context
        public IndexModel(ApplicationDbContext context) 
        {
            this._context = context;
        
        }

        // 
        public void OnGet()
        {
            //initialize this list
            products = _context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
