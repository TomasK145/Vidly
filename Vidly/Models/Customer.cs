using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)] //mozne pouzit Fluent API
        public string Name { get; set; }
        [Display(Name = "Day of Birth")] //umoznuje zmenu textu Labelu zobrazeneho pri kontrole
        public DateTime? Birthdate { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } //navigation property --> umoznuje navigaciu z jedneho typu do ineho
        public byte MembershipTypeId { get; set; } //v niektorych pripadoch ked nechceme z DB ziskat aj previazane itemy hned, staci ziskat ID, treba zachovat nazvovu konvenciu aby EF dokazalo rozoznat, ze sa jedna o FK
    }
}