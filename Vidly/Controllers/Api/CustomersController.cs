using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public CustomersController()
        {
            _context = new MyDbContext();
            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = _config.CreateMapper();
        }
        public IHttpActionResult GetCustomers()
        {
            IEnumerable<CustomerDto> customers = _context.Customers
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customers);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Select(_mapper.Map<Customer, CustomerDto>)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Content(HttpStatusCode.NotFound, $"Customer with Id {id} not found");

            return Ok(customer);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

                                            //source,    destination (source);
            Customer customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id ), customerDto );
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return Content(HttpStatusCode.NotFound, $"Customer with Id {id} not found");

            customerDto.Id = customerInDb.Id;
            _mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return Content(HttpStatusCode.NotFound, $"Customer with Id {id} not found");

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
