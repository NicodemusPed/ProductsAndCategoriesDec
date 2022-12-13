using ProductsAndCategoriesDec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
        return View("Categories", allCategories);
    }
}


