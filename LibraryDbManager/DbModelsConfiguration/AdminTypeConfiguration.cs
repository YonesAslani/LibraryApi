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
    public class AdminTypeConfiguration : IEntityTypeConfiguration<AdminType>
    {
        public void Configure(EntityTypeBuilder<AdminType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
