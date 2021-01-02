using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
	public class ArabalarController : Controller
	{
		// GET: List
		public ActionResult Index()
		{
			var cars = (new rentacarEntities()).cars.OrderByDescending(o => o.id).ToList();
			return View(cars);
		}
		public ActionResult Detay()
		{
			if (RouteData.Values["id"] == null) return Redirect("/");
			int ID = Convert.ToInt32(RouteData.Values["id"]);
			var Car = (new rentacarEntities()).cars.Where(w => w.id == ID).FirstOrDefault();
			return View(Car);
		}
	}
}