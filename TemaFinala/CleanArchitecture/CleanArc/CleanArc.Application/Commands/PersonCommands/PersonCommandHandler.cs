using MediatR;
using Microsoft.Extensions.Logging;
using CleanArc.Application.Interfaces;
using CleanArc.Common;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArc.Application.Services;

namespace CleanArc.Application.Commands.PersonCommands
{
    #region***Cornel***
    
    [MapServiceDependency(Name: nameof(PersonCommandHandler))]
    public class PersonCommandHandler : IRequestHandler<AddPersonCommand, AddPersonCommandResponse>,
                                        IRequestHandler<EditPersonCommand, EditPersonCommandResponse>,
                                        IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IRepository _repository;
        private readonly ILogger<PersonCommandHandler> _logger;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly INotificationService _notificationService;

        public PersonCommandHandler(IRepository repository, ILogger<PersonCommandHandler> logger, IEventDispatcher eventDispatcher, INotificationService notificationService)
        {
            _repository = repository;
            _logger = logger;
            _eventDispatcher = eventDispatcher;
            _notificationService = notificationService;
        }

        public async Task<AddPersonCommandResponse> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Guid newId = Guid.NewGuid();
            using (var uow = _repository.CreateUnitOfWork())
            {
                _logger.LogInformation("Entered Add person {0}", request.Person.LastName);
                var Person = new Person
                {
                    Id = newId,
                    LastName = request.Person.LastName,
                    FirstName = request.Person.FirstName,
                    Email = request.Person.Email,
                    UserId = request.User.UserId
            };
                uow.Add(Person);
                await uow.SaveChangesAsync(cancellationToken);
            }
            _eventDispatcher.Publish(new PersonAdded(newId));

            _logger.LogInformation("Finished Add person {0}", request.Person.LastName);
            return new AddPersonCommandResponse
            {
                PersonId = newId
            };
        }

        public async Task<EditPersonCommandResponse> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            using (var uow = _repository.CreateUnitOfWork())
            {
                var person = uow.GetEntities<Person>().Where(x => x.Id == request.Person.Id).FirstOrDefault();

                person.LastName = request.Person.LastName;
                person.FirstName = request.Person.FirstName;
                person.Email = request.Person.Email;

                await uow.SaveChangesAsync(cancellationToken);
            }
            return new EditPersonCommandResponse
            {
                PersonId = request.Person.Id.Value,
            };
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            using (var uow = _repository.CreateUnitOfWork())
            {
                var toRemovePerson = uow.GetEntities<Person>().FirstOrDefault(x => x.Id == request.Id);
                uow.Delete(toRemovePerson);
                await uow.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }

    #endregion***Cornel***
}
