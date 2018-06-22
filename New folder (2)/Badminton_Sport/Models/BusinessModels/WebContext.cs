namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebContext : DbContext
    {
        public WebContext()
            : base("name=WebContext")
        {
        }

        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<BILL_DETAIL> BILL_DETAIL { get; set; }
        public virtual DbSet<BUSINESS> BUSINESSes { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<PRODUCE> PRODUCEs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<SALE> SALEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BILL>()
                .Property(e => e.BILL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.APPROVAL_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .HasMany(e => e.BILL_DETAIL)
                .WithRequired(e => e.BILL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BILL_DETAIL>()
                .Property(e => e.BILL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BILL_DETAIL>()
                .Property(e => e.PRODUCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BUSINESS>()
                .Property(e => e.BUSINESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.CATEGORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCEs)
                .WithMany(e => e.CATEGORies)
                .Map(m => m.ToTable("CATEGORY_PRODUCE").MapLeftKey("CATEGORY_ID").MapRightKey("PRODUCE_ID"));

            modelBuilder.Entity<FEEDBACK>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FEEDBACK>()
                .Property(e => e.PRODUCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISSION>()
                .Property(e => e.PERMISSION_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISSION>()
                .Property(e => e.BUSINESS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCE>()
                .Property(e => e.PRODUCE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.IMAGES)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.SALEID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PRODUCE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.CATEGORY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.BILL_DETAIL)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.SALE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SALE>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SALE>()
                .HasMany(e => e.PRODUCTs)
                .WithOptional(e => e.SALE)
                .HasForeignKey(e => e.SALEID);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.BILLs)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.APPROVAL_ADMIN);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.BILLs1)
                .WithOptional(e => e.USER1)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.FEEDBACKs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
