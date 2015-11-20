using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Inheritence.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }

    public class SoloArtist : Artist
    {
        public string Instrument { get; set; }
    }
}