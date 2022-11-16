using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Customer : BaseEntity
    {
        Customer(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string adress,
            int number
        )
        {
            Fullname= fullName;
            Email= email;
            EmailConfirmation= emailConfirmation;
            Cpf= formatCpf(cpf);
            Cellphone = cellphone;
            DateOfBirth= dateOfBirth;
            EmailSms= emailSms;
            Whatsapp= whatsapp;
            Country= country;
            City= city;
            PostalCode= postalCode;
            Adress= adress;
            Number= number;
        }

        public string Fullname { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Adress { get; set; }
        public int Number { get; set; }

        string formatCpf( string cpf )
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
