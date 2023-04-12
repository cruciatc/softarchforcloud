using MediatR;
using CleanArc.Application.Interfaces;
using CleanArc.Application.QueryProjections;
using CleanArc.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Queries.ActivityQueries
{
    #region***Cornel***

    public class PersonQueryHandler : IRequestHandler<GetAllPersonQuery, GetAllPersonQueryResponse>,
                                      IRequestHandler<GetPersonByIdQuery, GetPersonByIdQueryResponse>,
                                      IRequestHandler<GetAllPersonByLastNameQuery, GetAllPersonByLastNameQueryResponse> 
    {
        private readonly IRepository _repository;

        public PersonQueryHandler(IRepository personRepository)
        {
            _repository = personRepository;
        }

        public async Task<GetAllPersonQueryResponse> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllPersonQueryResponse();
            var person = _repository.GetEntities<Person>().Where(x=> x.UserId == request.User.UserId).ToList();
            var personResponse = person.Select(x => new PersonProjection { Id = x.Id, LastName = x.LastName, FirstName = x.FirstName, Email = x.Email}).ToList();
            response.PersonModels = personResponse;
            return response;
        }

        public async Task<GetPersonByIdQueryResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetPersonByIdQueryResponse();
            var person = _repository.GetEntities<Person>().Where(x=> x.Id == request.PersonId && x.UserId == request.User.UserId).FirstOrDefault();
            var personResponse = new PersonProjection { Id = person.Id, LastName = person.LastName, FirstName = person.FirstName, Email = person.Email };
            response.Person = personResponse;
            return response;
        }

        public async Task<GetAllPersonByLastNameQueryResponse> Handle(GetAllPersonByLastNameQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllPersonByLastNameQueryResponse();
            var person = _repository.GetEntities<Person>().Where(x => x.LastName.Contains(request.PersonLastName)  && x.UserId == request.User.UserId).ToList();
            var personResponse = person.Select(x => new PersonProjection { Id = x.Id, LastName = x.LastName, FirstName = x.FirstName, Email = x.Email  }).ToList();
            response.PersonModels = personResponse;
            return response;
        }

    }

    #endregion***Cornel***
}
