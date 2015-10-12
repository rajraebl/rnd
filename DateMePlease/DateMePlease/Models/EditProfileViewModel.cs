using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DateMePlease.Validators;

namespace DateMePlease.Models
{
    public class EditProfileViewModel
    {

        public int Id { get; set; }

        //The error message will come in the sequence of Props in this class and not on the html view
        [StringLength(50,MinimumLength = 3,ErrorMessage = "{0} should be between {2} and {1}")]
        [Required]
        public string Pitch { get; set; }

        [DisplayName("Looking For")]
        [Required]
        public string LookingFor { get; set; }

        [Required]
        public string Introduction { get; set; }

        [DisplayName("Birthday")]
        [AgeRange(18,120,ErrorMessage = "{0} Your age must be bw {1}-{2} in {0}")]
        public DateTime Birthdate { get; set; }

        [Required()]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Gender Orientation")]
        public string Orientation { get; set; }

        public string MemberName { get; set; }
        
    }
}
