using PYP_PhoneDrectory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDrectory.Abstractions.Services
{
    public interface IContactService
    {
        bool Add(Contact contact);
        List<Contact> GetAll();
        Contact GetById(int id);
        bool Update(int id,Contact contact);
        void Delete(int Id);
       
    }
}
