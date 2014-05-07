using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCentre.Models
{
    public class CallLog
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        [Required]
        [MinLength(10)]
        public string Message { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime CallDate { get; set; }
    }
}