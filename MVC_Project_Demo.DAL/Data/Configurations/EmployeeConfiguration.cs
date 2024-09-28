using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Project_Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project_Demo.DAL.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Salary)
                .HasColumnType("decimal(18,2)");


            builder.Property(E => E.Gender)
                    .HasConversion(
                (Gender) => Gender.ToString(),
                (genderAsString) => (Gender)Enum.Parse(typeof(Gender), genderAsString, true)
                );
                //.HasConventions((Gender) => Gender.ToString())
                //(genderAsString)=> (Gender)Enum.Parse(typeof(Gender), genderAsString, true));

        }
    }
}
