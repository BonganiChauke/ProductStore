using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Models;
using ProductStore.Services;

namespace ProductStore.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        //variables
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        public string errorMessage = "";
        public string successMessage = "";


        [BindProperty]
        public ProductDetail productDetail { get; set; } = new ProductDetail();
        public Product Product { get; set; } = new Product();

        //constructor 
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            // if the id is null
            if(id == null)
            {
                // redirect the user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // to read product to read from the database
            var product = context.Products.Find(id);

            // checking the product variable is null
            if(product == null)
            {
                // redirect the user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            //initializing product variables
            productDetail.Name = product.Name;
            productDetail.Brand = product.Brand;
            productDetail.Category = product.Category;
            productDetail.Price = product.Price;
            productDetail.Description = product.Description;

            // initializing product property
            Product = product;

        }

        //on post function to send to database
        public void onPost(int? id)
        {
            // if the id is null
            if (id == null)
            {
                // redirect the user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            // check if form data is valid
            if (!ModelState.IsValid)
            {
                //error message
                errorMessage = "Please provide all the required fields";
                return;

            }

            // product 
            var product = context.Products.Find(id);

            // if the product is not found
            if(product == null)
            {
                // redirect the user
                Response.Redirect("/Admin/Products/Index");
                return;
            }

            //updating the image file 
            string newFileName = product.ImageFileName;

            //if image file is not null
            if(productDetail.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName = Path.GetExtension(productDetail.ImageFile!.FileName);

                string imageFullPath = environment.WebRootPath + "/products/" + newFileName;

                //creating a file to save the server of the new image
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productDetail.ImageFile.CopyTo(stream);

                }

                // delete the old image
                string oldImageFullPath = environment.WebRootPath + "/products/" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            //updating the product in the database
            product.Name = productDetail.Name;
            product.Brand = productDetail.Brand;
            product.Category = productDetail.Category;
            product.Price = productDetail.Price;
            product.Description = productDetail.Description ?? "";
            product.ImageFileName = newFileName;
            context.SaveChanges();

            //initializing the product property 
            Product = product;

            //success message
            successMessage = "Product updated successfully";

            // redirect the user
            Response.Redirect("/Admin/Products/Index");

        }
    }
}
