using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class SayfaController : Controller
    {
		public ActionResult Iletisim()
		{
			return View();
		}
		public ActionResult Duyurular()
		{
			return View((new rentacarEntities()).announcements.OrderByDescending(o => o.id).ToList());
		}
		public ActionResult Rezervasyon()
		{
			return View((new rentacarEntities()).cars.OrderByDescending(o => o.id).ToList());
		}
	}
}