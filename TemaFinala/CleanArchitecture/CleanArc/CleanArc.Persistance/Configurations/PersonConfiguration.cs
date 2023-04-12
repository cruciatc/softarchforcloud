using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArc.Domain.Entities;

namespace CleanArc.Persistance.Configurations
{
    #region***Cornel***

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();
        }
    }

    #endregion***Cornel***
}
