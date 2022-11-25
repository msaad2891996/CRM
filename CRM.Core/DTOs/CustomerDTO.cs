using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.DTOs
{
    public class CustomerDTO
    {
        public string Code { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ICollection<CustomerAddressDTO> CustomerAddresses { get; set; }

    }

    public class EditCustomerDto:CustomerDTO
    {
        public int Id { get; set; }
    }


    public class CustomerAddressDTO
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsShippingAddress { get; set; }
        public bool IsBillingAddress { get; set; }
    }
}
