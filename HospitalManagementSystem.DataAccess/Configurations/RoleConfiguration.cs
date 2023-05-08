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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
<<<<<<< HEAD
<<<<<<< HEAD
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
=======
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); 
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
=======
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); 
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
        }
    }
}
