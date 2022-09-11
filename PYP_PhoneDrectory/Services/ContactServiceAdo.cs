using PYP_PhoneDrectory.Abstractions.Services;
using PYP_PhoneDrectory.Entities;
using PYP_PhoneDrectory.Helpers.InputCheck;
using PYP_PhoneDrectory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Services
{
    public class ContactServiceAdo : IContactService
    {
        private readonly AdoNetRepository<Contact> adoNet;
        public ContactServiceAdo()
        {
                adoNet = new AdoNetRepository<Contact>();
        }
        public bool Add(Contact contact)
        {
            var result = (ContactCheck.CheckName(contact.Name) && ContactCheck.CheckName(contact.Surname) && ContactCheck.CheckEmail(contact.Email) && ContactCheck.CheckNumber(contact.PhoneNumber));
            if(result)
            {
                Console.WriteLine("Succes register");
                adoNet.Add(contact);
                return true;
            }
            Console.WriteLine("unsuccessful");
            return false;
        }

        public void Delete(int Id)
        {
            adoNet.Delete(adoNet.Get(x => x.Id == Id));
        }

        public List<Contact> GetAll()
        {
            return adoNet.GetAll();
        }

        public Contact GetById(int id)
        {
            return adoNet.Get(x => x.Id == id);
        }

        public bool Update(int id,Contact contact)
        {
            var result = (ContactCheck.CheckName(contact.Name) && ContactCheck.CheckName(contact.Surname) && ContactCheck.CheckEmail(contact.Email) && ContactCheck.CheckNumber(contact.PhoneNumber));
            if (result)
            {
                var dbContact=adoNet.Get(x => x.Id == id);
                dbContact.Name = contact.Name;
                dbContact.Surname = contact.Surname;
                dbContact.Email = contact.Email;
                dbContact.PhoneNumber = contact.PhoneNumber;
               return adoNet.Update(id,dbContact);
            }
            return false;
        }

       
    }
}
