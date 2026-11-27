using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
    [Table("EventOrganizers")]
    public  class Organizer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(150)]
        public string? CampanyName { get; set; }
        public bool IsVerified { get; set; }

        // One-to-One
        public OrganizerProfile? Profile { get; set; }

        // One-to-Many
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
