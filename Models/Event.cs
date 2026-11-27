using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
   public  class Event
    {
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public string Description { get; set; }=null!;
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public int OrganizerId { get; set; }
        public int MaxAttendees { get; set; }

        // Navigation Property
        public Organizer Organizer { get; set; } = null!;

    }

}
