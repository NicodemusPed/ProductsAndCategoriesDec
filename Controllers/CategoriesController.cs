using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategoriesDec.Models;

namespace ProductsAndCategoriesDec.Controllers;

public class CategoriesController : Controller
    {
    private  MyContext dbcontext;
    public CategoriesController(MyContext context)
    {
        dbcontext = context;
    }

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        List<Category> allCategories = dbcontext.Categories.ToList();
        return View("_Categories", allCategories);
    }
}


