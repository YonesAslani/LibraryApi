using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDbManager.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDbManager.DbModelsConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.BookName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BookWriter).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BookCount).IsRequired();

            //builder.HasOne()
        }
    }
}
