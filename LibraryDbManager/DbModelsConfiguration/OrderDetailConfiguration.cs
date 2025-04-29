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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.Book).WithMany(w => w.OrderDetails).HasForeignKey(o => o.BookId);
            builder.HasOne(h => h.Order).WithMany(h => h.Details).HasForeignKey(h => h.OrderId);
        }
    }
}
