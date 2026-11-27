using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        [Required]
        [StringLength(150)]
        public string FullName { get; set; } = null!;
        [Required]
        [StringLength(200)]
        public string Email { get; set; }=null!;
        [Required]
        [StringLength(150)]
        public string Street { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(20)]
        [Column("ZipCode")]
        public string PostalCode { get; set; } = null!;
        [NotMapped]
        public string FullAddress =>
        $"{Street}, {City}, {Country}, {PostalCode}";
        // One-to-One
        public Badge? Badge { get; set; }

    }
}
