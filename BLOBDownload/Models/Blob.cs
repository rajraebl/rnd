using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BLOBDownload.Models
{
    public class Blob
    {
        [Display(Name="Container Name")]
        [Required]
        public string ContainerName { get; set; }

        [Display(Name = "File Name")]
        [Required]
        public string FileName { get; set; }
    }
}