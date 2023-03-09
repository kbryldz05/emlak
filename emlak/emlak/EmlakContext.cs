using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlak
{
    internal class EmlakContext : DbContext
    {
        public DbSet<emlak> Emlaklar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OkulDbWinEmlak;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<emlak>().ToTable("tblEmlak");
            modelBuilder.Entity<emlak>().Property(o => o.OdaSayisi).HasColumnType("int").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<emlak>().Property(o => o.Metrekare).HasColumnType("int").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<emlak>().Property(o => o.Fiyat).HasColumnType("float").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<emlak>().Property(o => o.Sehir).HasColumnType("varchar").HasMaxLength(20).IsRequired();
        }
    }
}
