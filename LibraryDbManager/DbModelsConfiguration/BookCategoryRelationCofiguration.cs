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
    public class BookCategoryRelationCofiguration : IEntityTypeConfiguration<BookCategoryRelation>
    {
        public void Configure(EntityTypeBuilder<BookCategoryRelation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.CategoryId).IsRequired();
            builder.Property(p=>p.BookId).IsRequired();

            builder.HasOne(h => h.Book).WithMany(w => w.Categories).HasForeignKey(h => h.BookId);
            builder.HasOne(h => h.Category).WithMany(w =>w.Books).HasForeignKey(h => h.CategoryId);
        }
    }
}
