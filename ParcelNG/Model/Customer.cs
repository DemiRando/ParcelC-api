using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelNG.Model
{
    public class Customer
    {   [Key]
        public int CustomerID { get; set; }
        [Required]
        public String CustomerNumber { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class createCustomer : Customer
    {

    }
    public class readCustomer : Customer
    {
        public readCustomer(DataRow row)
        {

            CustomerID = Convert.ToInt32(row["CustomerID"]);
            CustomerNumber = row["CustomerNumber"].ToString();
            Title = row["Title"].ToString();
            FirstName = row["FirstName"].ToString();
            LastName = row["LastName"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
            if (!(row["UpdateDate"] is DBNull))
            {
                UpdateDate = Convert.ToDateTime(row["UpdateDate"]);
            }
            if (!(row["CreateDate"] is DBNull))
            {
                CreateDate = Convert.ToDateTime(row["CreateDate"]);
            }
        }
        
    }
}
