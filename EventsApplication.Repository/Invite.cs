//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventsApplication.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invite
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
