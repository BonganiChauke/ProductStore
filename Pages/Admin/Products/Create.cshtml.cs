using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Models;
using ProductStore.Services;

namespace ProductStore.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        // services variables
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        // message variables
        public string errorMessage = "";
        public string successMessage = "";

        // object of the model class
        [BindProperty]
        public ProductDetail productDetail { get; set; } = new ProductDetail();

        //constructor of the class and requesting services to be able to send image and db context
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            //fields
            this.environment = environment;
            this.context = context;
        }


        public void OnGet()
        {
        }

        //on post function to send information to database
        public void OnPost()
        {
            // validation for image file
            if(productDetail.ImageFile == null)
            {
                //error message
                ModelState.AddModelError("productDetail.ImageFile", "Product Image file is required");

            }

            // checking for errors on the form 
            if (!ModelState.IsValid)
            {
                //error message
                errorMessage = "Please provide all required fields";
                return;
            }

            // save the image
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            fileName = Path.GetExtension(productDetail.ImageFile!.FileName);

            //path of the image
            string imageFullPath = environment.WebRootPath + "/products/" + fileName;

            //creating a file to save the server of the new image
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productDetail.ImageFile.CopyTo(stream);

            }


            //save product in the database
            Product product = new Product()
            {
                // initializing product fields
                Name = productDetail.Name,
                Brand = productDetail.Brand,
                Price = productDetail.Price,
                Category = productDetail.Category,
                Description = productDetail.Description ?? "",
                ImageFileName = fileName,
                CreatedAt = DateTime.Now
            };

            //adding the product object to database
            context.Products.Add(product);
            context.SaveChanges();

            //clear the form
            productDetail.Name = "";
            productDetail.Brand = "";
            productDetail.Category = "";
            productDetail.Description = "";
            productDetail.Price = 0;
            productDetail.ImageFile = null;

            // clear model errors
            ModelState.Clear();

            // success message
            successMessage = "Product created successfully";

            // redirect the user to the list of products
            Response.Redirect("/Admin/Products/Index");

        }
    }
}
