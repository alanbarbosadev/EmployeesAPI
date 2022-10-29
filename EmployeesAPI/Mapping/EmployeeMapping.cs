using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesAPI.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Salary)
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(x => x.Birthday)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.DepartmentId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId);

            builder.HasData(
                new Employee(1, "Alan", "Barbosa", 1500, DateTime.Today, 1),
                new Employee(2, "Vanessa", "Barbosa", 1750, DateTime.Today, 1),
                new Employee(3, "Alex", "Cavalcante", 2000, DateTime.Today, 2),
                new Employee(4, "Uedemide", "Lopes", 2250, DateTime.Today, 2),
                new Employee(5, "Taylinne", "Oliveira", 2500, DateTime.Today, 3),
                new Employee(6, "Erivan", "Cavalcante", 2750, DateTime.Today, 3),
                new Employee(7, "Edvaldo", "Barbosa", 3000, DateTime.Today, 4),
                new Employee(8, "Eliza", "Rabay", 3250, DateTime.Today, 4),
                new Employee(9, "Edgar", "Poe", 3500, DateTime.Today, 5),
                new Employee(10, "Stephen", "King", 3750, DateTime.Today, 5)
                );
        }
    }
}
