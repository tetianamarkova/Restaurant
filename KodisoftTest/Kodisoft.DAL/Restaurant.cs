namespace Kodisoft.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Restaurant : DbContext
    {
        public Restaurant()
            : base("name=Restaurant")
        {
        }

        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<StatusList> StatusList { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItems>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.MenuItems)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Places>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Places)
                .HasForeignKey(e => e.OrderPlaceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusList>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.StatusList)
                .HasForeignKey(e => e.OrderStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tables>()
                .HasMany(e => e.Places)
                .WithRequired(e => e.Tables)
                .WillCascadeOnDelete(false);
        }
    }
}
