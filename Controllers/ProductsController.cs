#pragma warning disable CS8618

using ProductsAndCategoriesDec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategoriesDec.Controllers;

public class ProductsController : Controller
{
    private MyContext dbcontext;
    public ProductsController(MyContext context)
    {
        dbcontext = context;

    }
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> allProducts = dbcontext.Products.ToList();
        return View("Index", allProducts);
    }

    [HttpPost("product/new")]
    public IActionResult NewProduct()
    {
        return View("NewProduct");
    }

    [HttpPost("/product/create")]
    public IActionResult Create(Product newProduct)
    {
        if (!ModelState.IsValid)
        {
            return NewProduct();
        }
        dbcontext.Products.Add(newProduct);
        dbcontext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost("products/addcategory")]
    public IActionResult AddCategory(Association association)
    {
        if (!ModelState.IsValid)
        {
            dbcontext.Associations.Add(association);
            dbcontext.SaveChanges();
            return OneProduct(association.ProductId);
        }
        return OneProduct(association.ProductId);
    }


    [HttpGet("products/{id}")]
    public IActionResult OneProduct(int id)
    {
        Product? product = dbcontext.Products
            .Include(p => p.AssociatedCategories)
            .ThenInclude(a => a.Category)
            .FirstOrDefault(p => p.ProductId == id);

        ViewBag.allCategories = dbcontext.Categories.OrderBy(p => p.Name).ToList();
        return View("OneProduct", product);
    }
}


