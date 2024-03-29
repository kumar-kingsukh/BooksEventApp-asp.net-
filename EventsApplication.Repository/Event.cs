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
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Comments = new HashSet<Comment>();
            this.Invites = new HashSet<Invite>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime Date { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> DurationInHours { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public int UserId { get; set; }
        public Nullable<int> TotalInvites { get; set; }
        public string Type { get; set; }
        public string InviteEmails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invite> Invites { get; set; }
    }
}
