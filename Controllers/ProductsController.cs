using System.Diagnostics;
using ProductsAndCategoriesDec.Models;
using Microsoft.AspNetCore.Mvc;


namespace ProductsAndCategoriesDec.Controllers;

public class ProductsController : Controller
    {
    private  MyContext dbcontext;
    public ProductsController(MyContext context)
    {
        dbcontext = context;

    }
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> allProducts = dbcontext.Products.ToList();
        return View(allProducts);
    }

    [HttpPost("product/create")]
    public IActionResult NewProduct(Product newProduct)
    {
        
    }
}


