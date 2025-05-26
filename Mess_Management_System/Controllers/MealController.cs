using Mess_Management_System.Models;
using Mess_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mess_Management_System.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        public ActionResult Index()
        {
            var meals = _mealService.GetAll();
            return View(meals);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                _mealService.Add(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }
        public JsonResult GetMealEvents()
        {
            var meals = _mealService.GetAll();
            var events = meals.Select(m => new {
                title = $"Meal - {m.Breakfast + m.Lunch + m.Dinner}",
                start = m.MealDate.ToString("yyyy-MM-dd")
            });
            return Json(events, JsonRequestBehavior.AllowGet);
        }

    }
}