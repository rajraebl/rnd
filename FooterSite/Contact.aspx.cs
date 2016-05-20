using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FooterSite
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Locations = getFilledLocation();
            //if(Locations.SingleOrDefault()==null)
            if(Locations.FirstOrDefault()==null)
            {
                var k = 0;
            }
            var partnerProgramLocation = (
                from location in Locations
                select new PartnerProgramLocation()
                {
                    Name = location.Name,
                    ParentLocationId = location.City,
                    IsAuthorizedAdmin = true,
                }).ToList();

            var mm = partnerProgramLocation;
        }

        IEnumerable<Location> getFilledLocation()
        {
            var Locations = new List<Location>();
            for (int i = 0; i < 5; i++) {
                Locations.Add(new Location { Id = i, City = "City" + i, Name = "name" + i });
            }
                return Locations;
        }
    }
     class PartnerProgramLocation
    {
       public string Name { get; set; } 
       public string ParentLocationId { get; set; } 
       public bool  IsAuthorizedAdmin { get; set; } 
    }
    class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}