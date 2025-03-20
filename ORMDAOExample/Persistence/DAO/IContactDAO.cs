using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMDAOExample.DTOs;

namespace ORMDAOExample.Persistence.DAO
{
    public interface IContactDAO
    {
        public ContactDTO SelectContactByID(int id);
        public IEnumerable<ContactDTO> SelectAllContacts(); // Pot ser amb unaa llista també, després es pot fer filtratge aamb LINQ
        public void AddContacts(List<ContactDTO> contacts);
        public void AddContact(ContactDTO contact);
        public void UpdateContact(ContactDTO contact);
        public void DeleteContact(int id);
    }
}
