using CleanArc.Domain.Entities.Base;
using System;

namespace CleanArc.Domain.Entities
{
    #region ***Cornel***

    public class Person : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
    }

    #endregion ***Cornel***
}
