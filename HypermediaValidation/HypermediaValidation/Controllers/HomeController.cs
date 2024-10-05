using Microsoft.AspNetCore.Mvc;

namespace HypermediaValidation.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}