using HospitalManagementSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess.Configurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.InsuranceNumber).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(300);
            builder.Property(x => x.BloodType).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Allergy).IsRequired().HasMaxLength(100);
             
        }
    }
}
