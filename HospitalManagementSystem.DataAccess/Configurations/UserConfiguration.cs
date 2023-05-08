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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Mail).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TCIdNo).IsRequired();
<<<<<<< HEAD
<<<<<<< HEAD
=======
            
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
=======
            
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
        }
    }
}
