using Htmx;
using HypermediaValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace HypermediaValidation.Controllers;

public class SimpleController : Controller
{
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(UserWebModel model)
    {
        model.Validate(ModelState);
        if (Request.IsHtmx()) return PartialView("Partial/RegistrationPartial", model);
        if (!ModelState.IsValid) return View(model);

        return View("Complete");
    }
}