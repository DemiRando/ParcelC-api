using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ParcelNG.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>


        private SqlConnection _conn;
        private SqlDataAdapter _adapter;

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            _conn = new SqlConnection("data source=LAPTOP-PB27B2LT\\SQLEXPRESS;;Initial catalog=ParcelMessenger;user id=sa;password=Password123#;");
            DataTable dt = new DataTable();
            var query = "SELECT * FROM [ParcelMessenger].[dbo].[Customer]";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(dt);
            List<Customer> customers = new List<Customer>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow customerRecord in dt.Rows)
                {
                    customers.Add(new readCustomer(customerRecord));
                }
            }

            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
