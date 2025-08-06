using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Services;

namespace ProductStore.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        // constructor 
        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            // checking if id is null
            if(id == null)
            {
                // redirect user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // finding the id product
            var product = context.Products.Find(id);

            // if product is null
            if(product == null)
            {
                // redirect user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // delete the image
            string imageFullPath = environment.WebRootPath + "/products/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            // deleting the product from the database
            context.Products.Remove(product);
            context.SaveChanges();

            // redirect the user
            Response.Redirect("/Admin/Products/Index");

        }
    }
}
