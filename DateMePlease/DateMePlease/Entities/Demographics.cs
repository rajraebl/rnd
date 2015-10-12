﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DateMePlease.Entities
{
  public class Demographics
  {
    public int Id { get; set; }
    public string AddressLine { get; set; }
    public string CityTown { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    [DisplayName("Birthday")]
    public DateTime Birthdate { get; set; }
    public string Orientation { get; set; }
    public string Gender { get; set; }
  }
}
