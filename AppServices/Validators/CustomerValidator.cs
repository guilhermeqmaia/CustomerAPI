using DomainModels.Entities;
using DomainModels.Utilities;
using FluentValidation;
using FluentValidation.Validators;
using System.Linq;

namespace AppServices.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Fullname)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(customer => customer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(IsValidCpf)
                .WithMessage("Invalid CPF");

            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .Must(IsValidCellphone)
                .WithMessage("Cellphone is not valid, make sure that you provided a correct number");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is not valid");

            RuleFor(customer => customer.Country)
                .NotEmpty();

            RuleFor(customer => customer.City)
                .NotEmpty();

            RuleFor(customer => customer.PostalCode)
                .NotEmpty()
                .Must(IsValidPostalCode)
                .WithMessage("Invalid Postal Code");

            RuleFor(customer => customer.Address)
                .NotEmpty();

            RuleFor(customer => customer.Number)
                .NotEmpty();
        }

        public bool IsValidCpf(string cpf)
        {
            if (cpf.All(character => character == cpf.First()))
                return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = cpf.FormatCpf();

            if (cpf.Length != 11) return false;
            
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        public bool IsValidPostalCode(string postalCode)
        {
            if (postalCode.Length == 8)
                postalCode = postalCode.Substring(0, 5) + "-" + postalCode.Substring(5, 3);
            
            return System.Text.RegularExpressions.Regex.IsMatch(postalCode, ("[0-9]{5}-[0-9]{3}"));
        }

        public bool IsValidCellphone(string cellphone)
        {
            if (cellphone.Length < 10 || cellphone.Length > 11) return false;

            if (cellphone.Length == 11 && cellphone[2].ToString() != "9") return false;

            return true;
        }
    }
}
