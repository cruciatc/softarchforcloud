using MediatR;
using CleanArc.Application.Common;
using CleanArc.Application.QueryProjections;
using System;
using System.Collections.Generic;

namespace CleanArc.Application.Queries.ActivityQueries
{
    public class GetAllPersonQuery : BaseRequest<GetAllPersonQueryResponse>
    {
    }

    public class GetAllPersonQueryResponse
    {
        public List<PersonProjection> PersonModels { get; set; }
    }

    public class GetPersonByIdQuery : BaseRequest<GetPersonByIdQueryResponse>
    {
        public Guid PersonId { get; set; }
    }

    public class GetPersonByIdQueryResponse
    {
        public PersonProjection Person { get; set; }
    }

    public class GetAllPersonByLastNameQuery : BaseRequest<GetAllPersonByLastNameQueryResponse>
    {
        public string PersonLastName { get; set; }
    }

    public class GetAllPersonByLastNameQueryResponse
    {
        public List<PersonProjection> PersonModels { get; set; }
    }

}
