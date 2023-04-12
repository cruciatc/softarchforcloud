using System;

namespace CleanArc.Domain.Events
{
    #region***Cornel***

    public class PersonAdded : IEvent
    {
        public Guid PersonId { get; set; }

        public PersonAdded(Guid personId)
        {
            PersonId = personId;
        }
    }

    #endregion***Cornel***
}
