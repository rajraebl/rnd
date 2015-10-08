using System;
using System.Collections.Generic;
using DateMePlease.Entities;
namespace DateMePlease.Data
{
  public interface IDateMePleaseRepository
  {
    Profile GetProfileByUserName(string username);
    Profile GetProfile(string memberName);
    List<Profile> GetRandomProfiles(int numberToReturn);

    List<InterestType> GetInterestTypes();

    bool SaveAll();
  }
}
