using LibraryDbManager.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDbManager.DbModelsConfiguration
{
    public class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NationalCode).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PassWord).HasMaxLength(50);
        }
    }
}
