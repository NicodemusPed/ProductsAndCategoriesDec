#pragma warning disable CS8618

using Microsoft.AspNetCore.Mvc;
using ProductsAndCategoriesDec.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategoriesDec.Controllers;

public class CategoriesController : Controller
{
    private MyContext dbcontext;
    public CategoriesController(MyContext context)
    {
        dbcontext = context;
    }

    [HttpGet("categories")]
    public IActionResult Index()
    {
        List<Category> allCategories = dbcontext.Categories.ToList();
        return View("Index", allCategories);
    }

    [HttpPost("category/new")]
    public IActionResult NewCategory()
    {
        return View("NewCategory");
    }

    [HttpPost("/category/create")]
    public IActionResult create(Category newCategory)
    {
        if (!ModelState.IsValid)
        {
            return NewCategory();
        }
        dbcontext.Categories.Add(newCategory);
        dbcontext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost("products/addproduct")]
    public IActionResult AddCategory(Association association)
    {
        if (!ModelState.IsValid)
        {
            dbcontext.Associations.Add(association);
            dbcontext.SaveChanges();
            return OneCategory(association.CategoryId);
        }
        return OneCategory(association.CategoryId);
    }

    [HttpPost("categories/{id}")]
    public IActionResult OneCategory(int id)
    {
    Category? category = dbcontext.Categories
        .Include(p => p.AssociatedProducts)
        .ThenInclude(a => a.Product)
        .FirstOrDefault(p => p.CategoryId == id);

        ViewBag.allProducts = dbcontext.Products.OrderBy(c => c.ProductId == id).ToList();
        return View("OneCategory", category);
    }
}


