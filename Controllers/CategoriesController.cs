// include this using statement at the top of your controller file
using Microsoft.AspNetCore.Mvc.ModelBinding;



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

    [HttpPost("categories/addproduct")]
    public IActionResult AddProduct(Association association)
    {
        if (ModelState.IsValid)
        {
            dbcontext.Associations.Add(association);
            dbcontext.SaveChanges();
            return OneCategory(association.CategoryId);
        }
        return OneCategory(association.CategoryId);
    }

    [HttpGet("categories/{id}")]
    public IActionResult OneCategory(int id)
    {
        Category? category = dbcontext.Categories
            .Include(p => p.AssociatedProducts)
            .ThenInclude(a => a.Product)
            .FirstOrDefault(c => c.CategoryId == id);

        // this only allows categories to be listed once in the list.
        ViewBag.nonProducts = dbcontext.Products
            .Include(p => p.AssociatedCategories)
            .Where(p => p.AssociatedCategories.All(p => p.CategoryId != id)).OrderBy(p => p.Name).ToList();

        return View("OneCategory", category);
    }
}


