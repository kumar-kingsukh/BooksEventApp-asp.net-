﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Business.Models
{
    public class InviteDataModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
