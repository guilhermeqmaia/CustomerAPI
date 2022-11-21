using Data.Utilities;
using System;

namespace Data.Entities
{
    public class Customer
    {
        public Customer(
            long id,
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
            string address,
            int number
        )
        {
            Id = id;
            Fullname = fullName;
            Email= email;
            EmailConfirmation= emailConfirmation;
            Cpf = cpf.FormatCpf();
            Cellphone = cellphone.FormatCellphone();
            DateOfBirth= dateOfBirth;
            EmailSms= emailSms;
            Whatsapp= whatsapp;
            Country= country;
            City= city;
            PostalCode= postalCode.FormatPostalCode();
            Address= address;
            Number= number;
        }

        public long Id { get; set; }
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
        public string Address { get; set; }
        public int Number { get; set; }
    }
}
