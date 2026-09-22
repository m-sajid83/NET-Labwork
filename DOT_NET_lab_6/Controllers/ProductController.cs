using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_lab_6.Controllers
{
    public class ProductController : Controller
    {
        // Product Catalog
        public IActionResult Index()
        {
            return View();
        }

        // Product Details
        public IActionResult Details(int id)
        {
            if (id == 1)
            {
                ViewBag.ProductId = 1;
                ViewBag.ProductName = "Laptop";
                ViewBag.Description = "HP Laptop with 16GB RAM and 512GB SSD";
                ViewBag.Price = 80000;
            }
            else if (id == 2)
            {
                ViewBag.ProductId = 2;
                ViewBag.ProductName = "Mobile";
                ViewBag.Description = "Samsung Mobile with 8GB RAM and 128GB Storage";
                ViewBag.Price = 30000;
            }
            else if (id == 3)
            {
                ViewBag.ProductId = 3;
                ViewBag.ProductName = "Headphones";
                ViewBag.Description = "Wireless Bluetooth Headphones";
                ViewBag.Price = 5000;
            }

            return View();
        }
    }
}