using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesAPI.Mapping
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Deparment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.HasData(
                new Department (1, "Marketing"),
                new Department(2, "Accounting"),
                new Department(3, "Finances"),
                new Department(4, "Sales"),
                new Department(5, "Human Resources")
                );
        }
    }
}
