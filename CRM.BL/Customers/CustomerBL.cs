

using AutoMapper;

using CRM.Core;
using CRM.Core.DTOs;
using CRM.Core.Entities;
using CRM.DAL.DesignPattern;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BL.Customers
{
    public class CustomerBL
    {
        readonly IRepository<Customer> _RepCustomer;
        readonly IMapper _mapper;
        public CustomerBL(IRepository<Customer> RepCustomer, IMapper mapper)
        {
            _RepCustomer = RepCustomer;
            _mapper = mapper;
        }


        public ResponseDTO AddNewCustomer(CustomerDTO customerDTO)
        {

            ResponseDTO response = new ResponseDTO();
            try
            {

                var customerObj = _mapper.Map<Customer>(customerDTO);

                var action = _RepCustomer.Add(customerObj);


                response.Message = action ? "Customer Added Successfully" : "Error occur";
                response.IsSuccess = action;
                response.StatusCode = action ? 200 : 400;
            }
            catch (Exception ex)
            {

                response.Message = "Error occur";
                response.IsSuccess = false;
                response.StatusCode = 400;

                throw;
            }


            return response;
        }

    }
}
