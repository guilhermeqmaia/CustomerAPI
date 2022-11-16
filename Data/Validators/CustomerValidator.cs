using Data.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace CustomerAPI.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() {
            RuleFor(customer => customer.Fullname).NotEmpty();
            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(customer => customer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid");
            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(validateCpf)
                .WithMessage("Cpf is not valid");
            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("Cellphone is not valid, make sure that you provided a DDD");
            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is not valid");
            RuleFor(customer => customer.EmailSms)
                .NotNull();
            RuleFor(customer => customer.Whatsapp)
                .NotNull();
            RuleFor(customer => customer.Country)
                .NotEmpty();
            RuleFor(customer => customer.City)
                .NotEmpty();
            RuleFor(customer => customer.PostalCode)
                .NotEmpty();
            RuleFor(customer => customer.Adress)
                .NotEmpty();
            RuleFor(customer => customer.Number)
                .NotEmpty();        
        }
        public static bool validateCpf(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            return true;
        }
    }
}
