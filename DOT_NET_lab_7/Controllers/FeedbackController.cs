
using Microsoft.AspNetCore.Mvc;
using DOT_NET_lab_7.Models;

namespace DOT_NET_lab_7.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback model)
        {
            if (ModelState.IsValid)
            {
                TempData["UserName"] = model.Name;
                TempData["UserRating"] = model.Rating;

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            if (TempData["UserName"] == null)
            {
                return RedirectToAction("Create");
            }

            return View();
        }
    }
}
