using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMePlease.Data;
using DateMePlease.Extension;
using DateMePlease.Models;

namespace DateMePlease.Controllers
{
  [Authorize]
  public class MemberController : Controller
  {
    private IDateMePleaseRepository _repository;
    public MemberController()
    {
      _repository = new DateMePleaseRepository(new DateMePleaseContext());
    }

    public ActionResult EditProfile()
    {
        var currentProfile = _repository.GetProfileForEdit(User.Identity.Name);
        return View(currentProfile);
    }

    [HttpPost]
    public ActionResult EditProfile(EditProfileViewModel vm)
    {   //Needed to set tghis html atribute in html.textboxfor data_date_format="DD/MM/YYYY"
        //In each attribute we need to replace - by _ otherwise it will give error.

        /*THIS CODE WENT TO CUSTOME VALIDATION ATTRIBUTE.........
        var profileAge = vm.Birthdate.GetAge();

        if (profileAge > 120 || profileAge < 18)
        {
            ModelState.AddModelError("Birthdate", "Age should be between 18 and 120"); //here "Birthdate" seems case insensitive
        }
        */
        if (ModelState.IsValid)
        {
            var profile = _repository.GetProfile(vm.MemberName);
            profile.Introduction = vm.Introduction;
            profile.LookingFor = vm.LookingFor;
            profile.Pitch = vm.Pitch;
            profile.Demographics.Birthdate = vm.Birthdate;
            profile.Demographics.Gender = vm.Gender;
            profile.Demographics.Orientation = vm.Orientation;
            _repository.SaveAll();

            //profile
            return RedirectToAction("ShowProfile");
        }
        else
        {
            ModelState.AddModelError("","There is some error in the form.");
            return View(vm);
        }
    }

    [AllowAnonymous]
    public ActionResult ShowProfile(string id)
    {
      DateMePlease.Entities.Profile theProfile;

      if (string.IsNullOrWhiteSpace(id))
      {
        if (!User.Identity.IsAuthenticated)
        {
          return RedirectToAction("Index", "Home");
        }

        // Get the current user's profile
        theProfile = _repository.GetProfileByUserName(User.Identity.Name);
      }
      else
      {
        theProfile = _repository.GetProfile(id);
      }

      return View(theProfile);
    }

    public ActionResult EditPhotos()
    {
      return View();
    }

  }
}