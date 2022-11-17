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
                .MinimumLength(5);
            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(customer => customer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid");
            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(validateCpf);
            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("Cellphone is not valid, make sure that you provided a DDD");
            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is not valid");
            RuleFor(customer => customer.Country)
                .NotEmpty();
            RuleFor(customer => customer.City)
                .NotEmpty();
            RuleFor(customer => customer.PostalCode)
                .NotEmpty()
                .Must(validatePostalCode);
            RuleFor(customer => customer.Adress)
                .NotEmpty();
            RuleFor(customer => customer.Number)
                .NotEmpty();
        }
        public bool validateCpf(string cpf)
        {
            if (cpf.All(character => character == cpf.First()))
                return false;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
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
