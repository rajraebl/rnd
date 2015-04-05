using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace MVCWebRole.Models
{
    public class MailingList : TableEntity
    {
        public MailingList()
        {
            this.RowKey = "mailinglist";
        }

        [Required]
        [Display(Name="List Name")]
        [RegularExpression(@"[\w]+", ErrorMessage = @"Only alphanumeric characters and underscore (_) are allowed.")]
        public string ListName { get {return this.PartitionKey;} set {this.PartitionKey = value;} }

        [Required]
        [Display(Name="'From' Email Address")]
        public string FromEmailAddress { get; set; }


        public string Description { get; set; }
    }
}