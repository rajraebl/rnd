using System;
using System.Collections.Generic;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Data
{
  public interface IDateMePleaseRepository
  {
    Profile GetProfileByUserName(string username);
    Profile GetProfile(string memberName);

    EditProfileViewModel  GetProfileForEdit(string username);
    List<Profile> GetRandomProfiles(int numberToReturn);

    List<InterestType> GetInterestTypes();

    bool SaveAll();
  }
}
