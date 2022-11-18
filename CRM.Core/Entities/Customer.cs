using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Entities
{
    [Table("Customers")]
    public class Customer: BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }

    [Table("CustomerAddresses")]
    public class CustomerAddress: BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsShippingAddress  { get; set; }
        public bool IsBillingAddress  { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
