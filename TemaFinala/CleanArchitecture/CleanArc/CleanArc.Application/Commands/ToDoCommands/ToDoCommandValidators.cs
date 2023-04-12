using FluentValidation;
using CleanArc.Application.Interfaces;
using CleanArc.Application.Models;
using CleanArc.Common.Errors;
using CleanArc.Common.Localization;
using CleanArc.Domain.Entities;
using System;
using System.Linq;

namespace CleanArc.Application.Commands.ToDoCommands
{
    public class AddToDoCommandValidator : AbstractValidator<AddToDoCommand>
    {
        private readonly IRepository repository;

        public AddToDoCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            RuleFor(x => x.ToDo).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(ToDo)));
            RuleFor(x => x.ToDo.Name).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(ToDo.Name)));
            RuleFor(x => x.ToDo).Must(ImportantNameValidation).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.IMPORTANT_NAME), nameof(ToDo)));
        }

        private bool BeUnique(ToDoModel toDoModel)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x=> x.Name == toDoModel.Name);
            if (toDo != null && toDo.Id != toDoModel.Id)
            {
                return false;
            }
                return true;
        }

        private bool NotNullOrEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }

        private bool ImportantNameValidation(ToDoModel toDoModel)
        {
            if (toDoModel.Name.Contains("IMPORTANT"))
            {
                var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Name.Contains("IMPORTANT"));
                if (toDo != null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class EditToDoCommandValidator : AbstractValidator<EditToDoCommand>
    {
        private readonly IRepository repository;

        public EditToDoCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            
            RuleFor(x => x.ToDo).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(ToDo)));
            RuleFor(x => x.ToDo.Name).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(ToDo.Name)));
            RuleFor(x => x.ToDo.Id).Must(Exist).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.NOT_FOUND), nameof(ToDo)));
        }

        private bool BeUnique(ToDoModel toDoModel)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Name == toDoModel.Name);
            if (toDo != null && toDo.Id != toDoModel.Id)
            {
                return false;
            }
            return true;
        }

        private bool Exist(Guid? id)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Id == id);
            if (toDo == null)
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
}




