using System;
using System.ComponentModel.DataAnnotations;

namespace AzureDemo2.Models
{
    public class Contact
    {

        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
    }
}
