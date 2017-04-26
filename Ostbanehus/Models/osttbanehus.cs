namespace Ostbanehus.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class osttbanehus : DbContext
    {
        public osttbanehus()
            : base("name=osttbanehus")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.location)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Residents)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
