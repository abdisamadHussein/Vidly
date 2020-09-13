using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [Column(TypeName ="datetime2")]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }

    }
}