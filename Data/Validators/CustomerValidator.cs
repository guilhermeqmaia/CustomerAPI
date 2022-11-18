using Data.Entities;
using FluentValidation;
using FluentValidation.Validators;
using System.Runtime.ConstrainedExecution;

namespace CustomerAPI.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Fullname)
                .NotEmpty()
                .WithMessage("A name should be provided")
                .MinimumLength(5)
                .WithMessage("The Full Name passed was too short");
            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(customer => customer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid");
            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(validateCpf)
                .WithMessage("Invalid CPF");
            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("Cellphone is not valid, make sure that you provided a DDD");
            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is not valid");
            RuleFor(customer => customer.Country)
                .NotEmpty()
                .WithMessage("A Country should be provided");
            RuleFor(customer => customer.City)
                .NotEmpty()
                .WithMessage("A City must be provided");
            RuleFor(customer => customer.PostalCode)
                .NotEmpty()
                .WithMessage("A Postal Code should be provided")
                .Must(validatePostalCode)
                .WithMessage("Invalid Postal Code");
            RuleFor(customer => customer.Adress)
                .NotEmpty()
                .WithMessage("A Adress should be provided");
            RuleFor(customer => customer.Number)
                .NotEmpty()
                .WithMessage("A Number should be provided");
        }
        public bool validateCpf(string cpf)
        {
            if (cpf.All(character => character == cpf.First()))
                return false;
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            
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

        public bool validatePostalCode(string postalCode)
        {
            if (postalCode.Length == 8)
            {
                postalCode = postalCode.Substring(0, 5) + "-" + postalCode.Substring(5, 3);
            }
            return System.Text.RegularExpressions.Regex.IsMatch(postalCode, ("[0-9]{5}-[0-9]{3}"));
        }
    }
}
