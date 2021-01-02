using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Helpers
{
	public class Kullanici
	{
		public static bool Giris(string username, string password)
		{
			bool sonuc = false;

			rentacarEntities db = new rentacarEntities();
			var kontrol = db.admins.Where(w => w.username == username & w.password == password).FirstOrDefault();
			if (kontrol != null)
			{
				var token = Guid.NewGuid();
				sonuc = true;
				HttpCookie cookie = new HttpCookie("rentacaryonetici");
				cookie["Token"] = token.ToString();
				cookie.Expires = DateTime.Now.AddDays(1);
				HttpContext.Current.Response.Cookies.Add(cookie);
				kontrol.token = token.ToString();
				db.SaveChanges();
			}
			return sonuc;
		}

		public static bool Cikis()
		{
			bool sonuc = true;
			try
			{
				HttpCookie yenicookie = new HttpCookie("rentacaryonetici");
				yenicookie.Expires = DateTime.Now.AddDays(-1);
				HttpContext.Current.Response.Cookies.Add(yenicookie);
			}
			catch (Exception)
			{
				sonuc = false;
			}
			return sonuc;
		}

		public static admins Yonetici()
		{
			var Admin = new admins();
			if (HttpContext.Current.Request.Cookies["rentacaryonetici"] != null)
			{
				if (HttpContext.Current.Request.Cookies["rentacaryonetici"]["Token"] != null)
				{
					string Token = HttpContext.Current.Request.Cookies["rentacaryonetici"]["Token"].ToString();
					Admin = (new rentacarEntities()).admins.Where(w => w.token == Token).FirstOrDefault();
				}
			}
			return Admin;
		}

		public static bool GirisKontrol()
		{
			if (HttpContext.Current.Request.Cookies["rentacaryonetici"] != null)
			{
				if (HttpContext.Current.Request.Cookies["rentacaryonetici"]["Token"] != null)
				{
					string Token = HttpContext.Current.Request.Cookies["rentacaryonetici"]["Token"].ToString();
					if ((new rentacarEntities()).admins.Where(w => w.token == Token).FirstOrDefault() != null)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}