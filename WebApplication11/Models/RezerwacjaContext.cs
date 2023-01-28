using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication11.Models
{
    public partial class RezerwacjaContext : DbContext
    {
        public RezerwacjaContext()
            : base("name=Rezerwacja")
        {
        }

        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<Wypozyczone> Wypozyczone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezerwacja>()
                .Property(e => e.NazwaNart)
                .IsUnicode(false);
       

            modelBuilder.Entity<Rezerwacja>()
                .Property(e => e.OSOBA)
                .IsUnicode(false);

            modelBuilder.Entity<Wypozyczone>()
                .Property(e => e.NazwaNart)
                .IsUnicode(false);
    

            modelBuilder.Entity<Wypozyczone>()
                .Property(e => e.OSOBA)
                .IsUnicode(false);
        }
    }
}
