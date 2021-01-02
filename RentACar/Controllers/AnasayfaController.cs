using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
			var cars = (new rentacarEntities()).cars.OrderByDescending(o => o.id).Take(8).ToList();
			
            ViewData["topcars"]  = (new rentacarEntities()).cars.OrderByDescending(o => o.rank).Take(6).ToList();
			
            return View(cars);
        }
    }
}