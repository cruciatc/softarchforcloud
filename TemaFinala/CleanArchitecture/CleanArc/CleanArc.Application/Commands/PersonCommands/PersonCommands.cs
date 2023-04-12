using MediatR;
using CleanArc.Application.Common;
using CleanArc.Application.Models;
using System;

namespace CleanArc.Application.Commands.PersonCommands
{
    #region***Cornel***

    public class AddPersonCommand: BaseRequest<AddPersonCommandResponse>
    {
        public PersonModel Person { get; set; }
    }

    public class EditPersonCommand: BaseRequest<EditPersonCommandResponse>
    {
        public PersonModel Person { get; set; }
    }
    public class DeletePersonCommand: BaseRequest<Unit>
    {
        public Guid Id { get; set; }

    }

    public class AddPersonCommandResponse
    {
        public Guid PersonId { get; set; }
    }


    public class EditPersonCommandResponse
    {
        public Guid PersonId { get; set; }
    }

    #endregion***Cornel***
}
