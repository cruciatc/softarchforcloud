using MediatR;
using CleanArc.Application.Common;
using CleanArc.Application.QueryProjections;
using System;
using System.Collections.Generic;

namespace CleanArc.Application.Queries.ActivityQueries
{
    public class GetAllToDoQuery : BaseRequest<GetAllToDoQueryResponse>
    {
    }

    public class GetAllToDoQueryResponse
    {
        public List<ToDoProjection> ToDoModels { get; set; }
    }

    public class GetToDoByIdQuery : BaseRequest<GetToDoByIdQueryResponse>
    {
        public Guid ToDoId { get; set; }
    }

    public class GetToDoByIdQueryResponse
    {
        public ToDoProjection ToDo { get; set; }
    }
    #region ***Cornel***

    public class GetAllToDoByNameQuery : BaseRequest<GetAllToDoByNameQueryResponse>
    {
        public string ToDoName { get; set; }
    }

    public class GetAllToDoByNameQueryResponse
    {
        public List<ToDoProjection> ToDoModels { get; set; }
    }

    #endregion ***Cornel***
}
