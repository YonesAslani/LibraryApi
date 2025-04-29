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
    public class OderCofiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.CostmerId).IsRequired();
            builder.Property(p=>p.BookCount).IsRequired();
            builder.HasOne(h=>h.Costumer).WithMany(w=>w.Orders).HasForeignKey(x=>x.CostmerId);
        }
    }
}
