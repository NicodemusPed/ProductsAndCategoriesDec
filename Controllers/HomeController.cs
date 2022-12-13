using Microsoft.AspNetCore.Mvc;

namespace ProductsAndCategoriesDec.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


}
