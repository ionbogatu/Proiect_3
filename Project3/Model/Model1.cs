namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Database")
        {
        }

        public virtual DbSet<resource_attribute_values> resource_attribute_values { get; set; }
        public virtual DbSet<resource_attributes> resource_attributes { get; set; }
        public virtual DbSet<resource_eav> resource_eav { get; set; }
        public virtual DbSet<resource> resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<resource_attribute_values>()
                .HasMany(e => e.resource_eav)
                .WithRequired(e => e.resource_attribute_values)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resource_attributes>()
                .HasMany(e => e.resource_attribute_values)
                .WithRequired(e => e.resource_attributes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resource_attributes>()
                .HasMany(e => e.resource_eav)
                .WithRequired(e => e.resource_attributes)
                .HasForeignKey(e => e.resource_attributes_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resource>()
                .HasMany(e => e.resource_eav)
                .WithRequired(e => e.resource)
                .WillCascadeOnDelete(false);
        }
    }
}
