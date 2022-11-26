

using AutoMapper;

using CRM.Core;
using CRM.Core.DTOs;
using CRM.Core.Entities;
using CRM.DAL.DesignPattern;
using Microsoft.EntityFrameworkCore;
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
        readonly IRepository<CustomerAddress> _RepCustomerAddress;
        readonly IMapper _mapper;
        public CustomerBL(IRepository<Customer> RepCustomer, IMapper mapper,
            IRepository<CustomerAddress> repCustomerAddress)
        {
            _RepCustomer = RepCustomer;
            _mapper = mapper;
            _RepCustomerAddress = repCustomerAddress;
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
        public ResponseDTO EidtCustomer(EditCustomerDto mdl)
        {

            ResponseDTO response = new ResponseDTO();
            try
            {
                var customer = _RepCustomer.GetByIdDetched(mdl.Id);
                if (customer is not null)
                {

                      var customerObj = _mapper.Map<Customer>(mdl);
                    //customer.FirstName = mdl.FirstName;
                    //customer.LastName = mdl.LastName;
                    //customer.Email = mdl.Email;
                    //customer.Phone = mdl.Phone;
                    //customer.ModifiedDate = DateTime.Now;
                    var customersAddress = _RepCustomerAddress.GetAll().
                                                               Where(x => x.CustomerId == mdl.Id).ToList();
                    if (customersAddress is not null)
                    {
                        _RepCustomerAddress.DeleteRangeWithoutSaveChange(customersAddress);
                          List<CustomerAddress> customersAdrress = new List<CustomerAddress>();
                        #region OLD_WAY
                        //foreach (var address in mdl.CustomerAddresses)
                        //{
                        //    var obj = new CustomerAddress()
                        //    {
                        //        AddedDate = DateTime.Now,
                        //        AddressLine1 = address.AddressLine1,
                        //        AddressLine2 = address.AddressLine2,
                        //        IsBillingAddress = true,
                        //        IsShippingAddress = true,
                        //        ModifiedDate = DateTime.Now,
                        //        PostalCode = address.PostalCode,
                        //        State = address.State,
                        //        CustomerId = customerObj.ID,
                        //    };
                        //    customers.Add(obj);
                        //} 
                        #endregion


                        if (mdl.CustomerAddresses is not null)
                        {
                            customersAdrress = _mapper.Map<List<CustomerAddress>>(mdl.CustomerAddresses);
                            _RepCustomerAddress.DeleteRangeWithoutSaveChange(customersAddress);
                            //var CustomerAddresses = mdl.CustomerAddresses.Select(x => new CustomerAddress()
                            //{
                            //    AddressLine1 = x.AddressLine1,
                            //    AddressLine2 = x.AddressLine2,
                            //    IsBillingAddress = x.IsBillingAddress,
                            //    IsShippingAddress = x.IsShippingAddress,
                            //    PostalCode = x.PostalCode,
                            //    State = x.State,
                            //    CustomerId = customer.ID,
                            //}).ToList();
                           // customer.CustomerAddresses = CustomerAddresses;
                          //  _RepCustomerAddress.AddRangeWithoutSaveChanges(CustomerAddresses);
                        }
                        var action = _RepCustomer.Edit(customer);
                        if (action)
                        {
                            //   _RepCustomerAddress.AddRange(customersAdrress);
                            response.Message = action ? "Customer Added Successfully" : "Error occur";
                            response.IsSuccess = action;
                            response.StatusCode = action ? 200 : 400;
                        }
                    }
                }
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

        public CustomerDTO GetCustomerById(int Id)
        {
            var entity = _RepCustomer.GetAll()
                                   .Include(x => x.CustomerAddresses)
                                   .Where(xx => xx.ID == Id)
                                   .FirstOrDefault();
            return _mapper.Map<CustomerDTO>(entity);
        }

        public List<CustomerDTO> GetAll()
        {
            var data = _RepCustomer.GetAll().ToList();
            return _mapper.Map<List<CustomerDTO>>(data);
        }

        public ResponseDTO EditCustomerStatus(int customerId, bool isActive)
        {

            ResponseDTO response = new ResponseDTO();
            try
            {

                var entity = _RepCustomer.GetById(customerId);

                entity.IsActive = isActive;

                var action = _RepCustomer.Edit(entity);

                response.Message = action ? "Customer Active Status updated Successfully" : "Error occur";
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
