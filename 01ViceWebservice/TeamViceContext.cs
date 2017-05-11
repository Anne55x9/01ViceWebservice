namespace _01ViceWebservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TeamViceContext : DbContext
    {
        public TeamViceContext()
            : base("name=TeamViceContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Appartment> Appartments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartment>()
                .Property(e => e.AssignTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Appartment>()
                .Property(e => e.AssignText)
                .IsUnicode(false);

            modelBuilder.Entity<Appartment>()
                .Property(e => e.AppartmentOwner)
                .IsUnicode(false);

            modelBuilder.Entity<Appartment>()
                .Property(e => e.Comment)
                .IsUnicode(false);
        }
    }
}
