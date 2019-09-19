using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class InviteViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserEmail { get; set; }
    }
}