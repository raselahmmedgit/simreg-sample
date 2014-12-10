using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RnD.TestSample.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [DisplayName("Name: ")]
        public string  Name { get; set; }
        [DisplayName("Email: ")]
        public string Email { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }

    }

    public class Address
    {
        public int Id { get; set; }
        [DisplayName("Address: ")]
        public string Name { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }
        [DisplayName("Contact Number: ")]
        public string Number { get; set; }
    }
}