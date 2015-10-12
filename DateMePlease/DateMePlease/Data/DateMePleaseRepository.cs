using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Data
{
  public class DateMePleaseRepository : IDateMePleaseRepository
  {
    private DateMePleaseContext _context;
    public DateMePleaseRepository(DateMePleaseContext context)
    {
      _context = context;
    }

    public Profile GetProfileByUserName(string userName)
    {
      var lowerUserName = userName.ToLowerInvariant();

      return _context.Profile
                     .Include("Demographics")
                     .Include("Interests.InterestType")
                     .Include("Photos")
                     .Include("Member")
                     .Where(m => m.Member.UserName.ToLower() == lowerUserName).FirstOrDefault();
    }

    public Profile GetProfile(string memberName)
    {
      var lowerMemberName = memberName.ToLowerInvariant();

      return _context.Profile
                     .Include("Demographics")
                     .Include("Interests.InterestType")
                     .Include("Photos")
                     .Include("Member")
                     .Where(m => m.Member.MemberName.ToLower() == lowerMemberName).FirstOrDefault();
    }

    public EditProfileViewModel GetProfileForEdit(string userName)
    {
        var lowerUserName = userName.ToLowerInvariant();

        return _context.Profile
            .Include("Demographics")
            .Include("Member")
            .Where(m => m.Member.UserName.ToLower() == lowerUserName)
            .Select(p => new EditProfileViewModel()
            {
                Id = p.Id,
                Pitch = p.Pitch,
                LookingFor = p.LookingFor,
                Introduction = p.Introduction,
                Birthdate = p.Demographics.Birthdate,
                Gender = p.Demographics.Gender,
                Orientation = p.Demographics.Orientation,
                MemberName = p.Member.MemberName
            }).FirstOrDefault();
    }


    public List<Profile> GetRandomProfiles(int numberToReturn)
    {
      return _context.Profile.Include("Photos")
                             .Include("Member")
                             .OrderBy(p => Guid.NewGuid())
                             .Take(numberToReturn)
                             .ToList();
    }

    public bool SaveAll()
    {
      try
      {
        return (!_context.ChangeTracker.HasChanges()) || _context.SaveChanges() > 0; // only return true if at least one row was changed
      }
      catch (Exception ex)
      {
        // TODO Add logging
        return false;
      }
    }

    public List<InterestType> GetInterestTypes()
    {
      return _context.InterestTypes.OrderBy(i => i.Name).ToList();
    }
  }
}