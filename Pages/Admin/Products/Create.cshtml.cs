using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Models;

namespace ProductStore.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        // object of the model class
        [BindProperty]
        public ProductDetail productDetail { get; set; } = new ProductDetail();

        public void OnGet()
        {
        }
    }
}
