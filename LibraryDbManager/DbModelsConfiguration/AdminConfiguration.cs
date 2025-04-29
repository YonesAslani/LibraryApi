using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDbManager.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDbManager.DbModelsConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PassWord).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(p => p.AdminTypeId).IsRequired();
            builder.HasKey(p => p.Id);
            builder.HasOne(h => h.AdminType).WithOne(w => w.Admin).HasForeignKey<Admin>(i => i.AdminTypeId);
        }
    }
}
