using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategoriesDec.Models;

namespace ProductsAndCategoriesDec.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}
