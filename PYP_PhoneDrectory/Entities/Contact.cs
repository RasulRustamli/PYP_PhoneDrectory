using PYP_PhoneDrectory.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Entities
{
    public class Contact:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Contact()
        {

        }
        public Contact(string name,string surname,string email,string phonenumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phonenumber;
        }
    }
}
