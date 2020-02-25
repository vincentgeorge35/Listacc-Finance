using System;
using System.ComponentModel.DataAnnotations;

namespace ListaccFinance.API.SendModel

{
    public class SyncLoginModel
    {
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientMacAddress { get; set; }
        [Required]
        public string ClientType { get; set; }

        [Required]
        public string Password {get; set;}

        [Required]
        public string EmailAddress {get; set;}
    }

    public class UserLogin 
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }

    public class RegisterModel
    {
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public string Phone { get; set; }
        public string Address { get; set; }

        public string EmailAddress {get; set;}
        public string Password { get; set; }
        public string Department {get; set;}
        public Nullable<int> DepartmentId {get; set;}
        
    }


    public class DesktopCreateModel
    {

        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientMacAddress { get; set; }
        [Required]
        public string ClientType { get; set; }
    }

    public class DataDownload
    {
        [Required]
        public string MacAddress {get; set;}
        public DateTime lastUpdate {get; set;}
    }


}