﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //Data annotation su vyuzite pre server-side aj client-side validation
        [Required(ErrorMessage = "Please enter customer's name.")] //moznost editacie validacnej hlasky
        [StringLength(255)] //mozne pouzit Fluent API
        public string Name { get; set; }

        [Display(Name = "Day of Birth")] //umoznuje zmenu textu Labelu zobrazeneho pri kontrole
        [Min18YearsIfAMember] //jquery client-side validation supportuje len standarne data annotation (nie custom)
        public DateTime? Birthdate { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //navigation property --> umoznuje navigaciu z jedneho typu do ineho

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; } //v niektorych pripadoch ked nechceme z DB ziskat aj previazane itemy hned, staci ziskat ID, treba zachovat nazvovu konvenciu aby EF dokazalo rozoznat, ze sa jedna o FK
        //MembershipTypeId - property je implicitne required - byte nemoze byt null
    }
}