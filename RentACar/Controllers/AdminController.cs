using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			var cars = (new rentacarEntities()).cars.OrderByDescending(o => o.id).ToList();
			return View(cars);
		}
		public ActionResult YeniArac()
		{
			return View();
		}
		public ActionResult AracDuzenle()
		{
			if (RouteData.Values["id"] == null) return Redirect("/");
			int ID = Convert.ToInt32(RouteData.Values["id"]);
			var Car = (new rentacarEntities()).cars.Where(w => w.id == ID).FirstOrDefault();
			return View(Car);
		}
		public ActionResult RezervasyonIslem()
		{
			if (RouteData.Values["id"] == null) return Redirect("/");
			int ID = Convert.ToInt32(RouteData.Values["id"]);
			var Reservation = (new rentacarEntities()).reservations.Where(w => w.id == ID).FirstOrDefault();
			return View(Reservation);
		}
		public ActionResult Rezervasyonlar()
		{
			var reservations = (new rentacarEntities()).reservations.OrderByDescending(o => o.id).ToList();
			return View(reservations);
		}
		public ActionResult Duyurular()
		{
			var announcements = (new rentacarEntities()).announcements.OrderByDescending(o => o.id).ToList();
			return View(announcements);
		}
		public ActionResult DuyuruEkle()
		{
			return View();
		}
		public ActionResult DuyuruDuzenle()
		{
			if (RouteData.Values["id"] == null) return Redirect("/");
			int ID = Convert.ToInt32(RouteData.Values["id"]);
			var announcements = (new rentacarEntities()).announcements.Where(w => w.id == ID).FirstOrDefault();
			return View(announcements);
		}
		public ActionResult Yoneticiler()
		{
			var admins = (new rentacarEntities()).admins.OrderByDescending(o => o.id).ToList();
			return View(admins);
		}
		public ActionResult YoneticiEkle()
		{
			return View();
		}
		public ActionResult YoneticiDuzenle()
		{
			if (RouteData.Values["id"] == null) return Redirect("/");
			int ID = Convert.ToInt32(RouteData.Values["id"]);
			var admins = (new rentacarEntities()).admins.Where(w => w.id == ID).FirstOrDefault();
			return View(admins);
		}
	}
}