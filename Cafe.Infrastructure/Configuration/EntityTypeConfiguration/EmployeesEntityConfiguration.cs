using Cafe.Domain.Features.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Infrastructure.Configuration.EntityTypeConfiguration
{
    public class EmployeesEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        private readonly bool _isEmpty;

        public EmployeesEntityConfiguration(bool isEmpty)
        {
            _isEmpty = isEmpty;
        }
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.EmployeeSequence");


            for (int i = 1; i <= 30; i++)
            {
                builder
                    .HasData(new EmployeeEntity
                    {
                        Id = i,
                        Age = i + i,
                        Name = $"Ayman {i}",
                        PhoneNumber = $"01029045270 {i}",
                    });
            }
        }
    }
}