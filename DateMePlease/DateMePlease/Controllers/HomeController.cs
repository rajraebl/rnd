using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMePlease.Data;

namespace DateMePlease.Controllers
{
  public class HomeController : Controller
  {
    private IDateMePleaseRepository _repository;
    public HomeController()
    {
      _repository = new DateMePleaseRepository(new DateMePleaseContext());
    }

    public ActionResult Index()
    {
        var randomProfile = _repository.GetRandomProfiles(6);
        return View(randomProfile);
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

    public ActionResult Acknowledgements()
    {
      return View();
    }
  }
}