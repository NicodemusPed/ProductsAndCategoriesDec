using ProductsAndCategoriesDec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ProductsAndCategoriesDec.Controllers;

public class CategoriesController : Controller
    {
    private  MyContext db;
    public CategoriesController(MyContext context)
    {
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Categories> allCategories = db.Categories.ToList();
        return View("Categories", allCategories);
    }
}


