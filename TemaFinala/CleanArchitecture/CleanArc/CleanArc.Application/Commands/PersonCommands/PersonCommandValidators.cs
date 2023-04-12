using FluentValidation;
using CleanArc.Application.Interfaces;
using CleanArc.Application.Models;
using CleanArc.Common.Errors;
using CleanArc.Common.Localization;
using CleanArc.Domain.Entities;
using System;
using System.Linq;

namespace CleanArc.Application.Commands.PersonCommands
{
    #region***Cornel***

    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        private readonly IRepository repository;

        public AddPersonCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            RuleFor(x => x.Person).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(Person)));
            RuleFor(x => x.Person.LastName).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.LastName)));
            RuleFor(x => x.Person.FirstName).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.FirstName)));
            RuleFor(x => x.Person.Email).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.Email)));
        }

        private bool BeUnique(PersonModel personModel)
        {
            var person = repository.GetEntities<Person>().FirstOrDefault(x=> x.Email == personModel.Email);
            if (person != null && person.Id != personModel.Id)
            {
                return false;
            }
                return true;
        }

        private bool NotNullOrEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }

    }

    public class EditPersonCommandValidator : AbstractValidator<EditPersonCommand>
    {
        private readonly IRepository repository;

        public EditPersonCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            
            RuleFor(x => x.Person).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(Person)));
            RuleFor(x => x.Person.LastName).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.LastName)));
            RuleFor(x => x.Person.FirstName).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.FirstName)));
            RuleFor(x => x.Person.Email).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(Person.Email)));
            RuleFor(x => x.Person.Id).Must(Exist).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.NOT_FOUND), nameof(Person)));
        }

        private bool BeUnique(PersonModel personModel)
        {
            var person = repository.GetEntities<Person>().FirstOrDefault(x => x.Email == personModel.Email);
            if (person != null && person.Id != personModel.Id)
            {
                return false;
            }
            return true;
        }

        private bool Exist(Guid? id)
        {
            var person = repository.GetEntities<Person>().FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return false;
            }
            return true;
        }
        private bool NotNullOrEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }

    #endregion***Cornel***
}




