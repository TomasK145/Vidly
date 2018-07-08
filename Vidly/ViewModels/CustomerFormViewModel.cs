using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //pouzitie IEnumerable namiesto List zabezpecuje viac loosly coupled
        public Customer Customer { get; set; }
    }
}