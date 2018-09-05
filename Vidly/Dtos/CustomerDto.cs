using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        //v Dto pouzivame primitivne typy (int, string, ...) alebo custom DTO objekty

        public int Id { get; set; }

        [StringLength(255)] 
        public string Name { get; set; }

        [Min18YearsIfAMember] 
        public DateTime? Birthdate { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}