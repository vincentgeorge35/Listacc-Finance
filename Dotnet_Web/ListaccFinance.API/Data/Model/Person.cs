using System.Collections.Generic;

namespace ListaccFinance.API.Data.Model
{
    public class Person
    {
        public int Id {get;set;}
        public string Surname {get;set;}
        public string LastName {get;set;}
        public string Gender {get;set;}
        public ICollection<Client> Clients { get; set; }

    }
}