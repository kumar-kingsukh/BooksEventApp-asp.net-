using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class EventViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        [StringLength(20, ErrorMessage =
            "Name should be less than or equal to 20 characters.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
            , ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Event Location")]
        public string Location { get; set; }

        [Display(Name = "Event Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Duration")]
        public int? DurationInHours { get; set; }

        public string Description { get; set; }

        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Invite Emails")]
        public string InviteEmails { get; set; }

        public int TotalInvites { get; set; }

        public string Type { get; set; }
    }
}