using CRM.BL.Customers;
using CRM.Core;
using CRM.Core.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        readonly CustomerBL _customerBL;
        public CustomerController(CustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        [HttpPost]
        public IActionResult AddNewCustomer([FromBody] CustomerDTO customerDTO)
        {
            return Ok(_customerBL.AddNewCustomer(customerDTO));
        }

        [HttpPost]
        public IActionResult EditCustomerStatus(int customerId, bool isActive)
        {
            return Ok(_customerBL.EditCustomerStatus(customerId, isActive));
        }
    }
}
