using ProductsAndCategoriesDec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace ProductsAndCategoriesDec.Controllers;

public class ProductsController : Controller
    {
    private  MyContext db;
    public ProductsController(MyContext context)
    {
        db = context;

    }
    // [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> allProducts = db.Products.ToList();
        return View("Products", allProducts);
    }
}


