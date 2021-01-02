using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
	public class IslemController : Controller
	{
		// GET: Islem
		public JsonResult Kayit(reservations formdata)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			string RezervasyonKodu = Random(6);
			bool sonuc = true;
			try
			{
				rentacarEntities db = new rentacarEntities();
				reservations YeniKayit = new reservations();
				YeniKayit.cars = formdata.cars;
				YeniKayit.city = formdata.city;
				YeniKayit.email = formdata.email;
				YeniKayit.isclose = false;
				YeniKayit.name = formdata.name;
				YeniKayit.phone = formdata.phone;
				YeniKayit.reservationtime = formdata.reservationtime;
				YeniKayit.reservationcode = RezervasyonKodu;
				db.reservations.Add(YeniKayit);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				sonuc = false;
			}
			dic["sonuc"] = sonuc;
			dic["rezervasyonkodu"] = RezervasyonKodu;
			return Json(dic);
		}

		public JsonResult RezervasyonTakip(string TakipKodu)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			try
			{
				dic["sonuc"] = 1;
				var araclar = new List<cars>();
				rentacarEntities db = new rentacarEntities();
				var bul = db.reservations.Where(w => w.reservationcode == TakipKodu).FirstOrDefault();
				dic["rezervasyon"] = bul;
				if (bul == null)
				{
					dic["sonuc"] = 2;
					return Json(dic);
				}
				var aracbul = bul.cars.Split(',');
				for (int i = 0; i < aracbul.Length; i++)
				{
					var aracid = Convert.ToInt32(aracbul[i].Trim());
					araclar.Add(db.cars.Where(w => w.id == aracid).FirstOrDefault());
				}
				dic["araclar"] = araclar;
			}
			catch (Exception)
			{
				dic["sonuc"] = 0;
			}
			return Json(dic);
		}

		public static string Random(int karakter)
		{
			Random RASTGELE = new Random();
			string KARAKTERLER = "ABCDEFGHIJKLMNOPRSTUVYZQWX0123456789";
			string SONUC = "";
			for (int i = 0; i < karakter; i++)
			{
				SONUC += KARAKTERLER[RASTGELE.Next(KARAKTERLER.Length)];
			}
			return SONUC;
		}

		public JsonResult Giris(string username, string password)
		{
			return Json(Helpers.Kullanici.Giris(username, password));
		}

		public JsonResult Cikis(string username, string password)
		{
			return Json(Helpers.Kullanici.Cikis());
		}

		public JsonResult AracKayit(cars formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					cars YeniKayit = new cars();
					YeniKayit.brand = formdata.brand;
					YeniKayit.color = formdata.color;
					YeniKayit.img = formdata.img;
					YeniKayit.km = formdata.km;
					YeniKayit.model = formdata.model;
					YeniKayit.modelyear = formdata.modelyear;
					YeniKayit.period = formdata.period;
					YeniKayit.price = formdata.price;
					YeniKayit.title = formdata.title;
					db.cars.Add(YeniKayit);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult AracDuzenle(cars formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					cars bul = db.cars.Where(w => w.id == formdata.id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					bul.brand = formdata.brand;
					bul.color = formdata.color;
					bul.img = formdata.img;
					bul.km = formdata.km;
					bul.model = formdata.model;
					bul.modelyear = formdata.modelyear;
					bul.period = formdata.period;
					bul.price = formdata.price;
					bul.title = formdata.title;
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult RezervasyonIslem(reservations formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					reservations bul = db.reservations.Where(w => w.id == formdata.id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					bul.reservationadminnot = formdata.reservationadminnot;
					bul.reservationnot = formdata.reservationnot;
					bul.isclose = formdata.isclose;
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult AracSil(int id)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					var arac = db.cars.Where(w => w.id == id).FirstOrDefault();
					if (arac == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					db.cars.Remove(arac);
					db.SaveChanges();
				}
				catch (Exception)
				{
					sonuc = 0;
					throw;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult RezervasyonSil(int id)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					var bul = db.reservations.Where(w => w.id == id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					db.reservations.Remove(bul);
					db.SaveChanges();
				}
				catch (Exception)
				{
					sonuc = 0;
					throw;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult DuyuruSil(int id)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					var bul = db.announcements.Where(w => w.id == id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					db.announcements.Remove(bul);
					db.SaveChanges();
				}
				catch (Exception)
				{
					sonuc = 0;
					throw;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult DuyuruEkle(announcements formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					announcements YeniKayit = new announcements();
					YeniKayit.title = formdata.title;
					YeniKayit.description = formdata.description;
					db.announcements.Add(YeniKayit);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult DuyuruDuzenle(announcements formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					announcements bul = db.announcements.Where(w => w.id == formdata.id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					bul.title = formdata.title;
					bul.description = formdata.description;
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult YoneticiSil(int id)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				if (Helpers.Kullanici.Yonetici().id != id)
				{
					try
					{
						rentacarEntities db = new rentacarEntities();
						var bul = db.admins.Where(w => w.id == id).FirstOrDefault();
						if (bul == null)
						{
							sonuc = 3;
							return Json(sonuc);
						}
						db.admins.Remove(bul);
						db.SaveChanges();
					}
					catch (Exception)
					{
						sonuc = 0;
					}
				}
				else
				{
					sonuc = 4;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult YoneticiEkle(admins formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					admins YeniKayit = new admins();
					YeniKayit.name = formdata.name;
					YeniKayit.username = formdata.username;
					YeniKayit.password = formdata.password;
					db.admins.Add(YeniKayit);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

		public JsonResult YoneticiDuzenle(admins formdata)
		{
			int sonuc = 1;
			if (Helpers.Kullanici.GirisKontrol())
			{
				try
				{
					rentacarEntities db = new rentacarEntities();
					admins bul = db.admins.Where(w => w.id == formdata.id).FirstOrDefault();
					if (bul == null)
					{
						sonuc = 3;
						return Json(sonuc);
					}
					bul.name = formdata.name;
					bul.username = formdata.username;
					bul.password = formdata.password;
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					sonuc = 0;
				}
			}
			else
			{
				sonuc = 2;
			}
			return Json(sonuc);
		}

	}
}