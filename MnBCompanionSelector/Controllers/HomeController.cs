using MnBCompanionSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MnBCompanionSelector.Controllers
{
	public class HomeController : Controller
	{
		public List<Companion> dbcon=CompanionList.getListfromDB();

		public ActionResult Details(int inp=1)
		{
			Companion model =(Companion) from r in dbcon
						where r.Id==inp
						select r;
			return PartialView(model);
		}
		public ActionResult Index()
		{
			var model = new CompanionLogicBag()
			{
				AvailableList = from r in dbcon
								select r
								,
				Mods = (from r in dbcon
						select r.ModName).Distinct()
			}
			;
			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}