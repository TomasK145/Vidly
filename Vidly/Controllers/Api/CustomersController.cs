using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers --> vstavana konvencia
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            //zabezpeci ze objekty Customerov su po ziskani z DB premapovane automaperom do CustomerDto
            return Ok(customerDtos);
        }

        //GET /api/customers/
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); //throw new HttpResponseException(HttpStatusCode.NotFound); //response ak nebol customer najdeny
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        //podla konvencie ak vytvarame resource je tento resource vrateny klientovi
        [HttpPost] //action bude volana len pri POST requeste (alebo mozeme nazvat metodu PostCustomer (vtedy netreba uviest atribut) --> odporucane aplikovat atribut)
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) //overenie validity modelu vramci action
            {
                return BadRequest();//throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges(); //po ulozeni je nastavene ID, mozeme vratit klientovi

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/
        //podla konvencie moze byt vrateny void alebo objekt
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) //overenie validity modelu vramci action
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
