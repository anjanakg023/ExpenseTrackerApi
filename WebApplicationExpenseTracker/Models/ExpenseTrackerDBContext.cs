using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationExpenseTracker.Models
{
    public partial class ExpenseTrackerDBContext : DbContext
    {
        public ExpenseTrackerDBContext()
        {
        }

        public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ItemList> ItemList { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Users> Users { get; set; }

      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= ANJANAKG\\SQLEXPRESS; Initial Catalog= ExpenseTrackerDB; Integrated security=True");
            }
        }
      */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__categori__23CAF1F88D57888C");

                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.Expenseid)
                    .HasName("PK__expenses__36737706C6F7B45A");

                entity.ToTable("expenses");

                entity.Property(e => e.Expenseid).HasColumnName("expenseid");

                entity.Property(e => e.Expensedate)
                    .HasColumnName("expensedate")
                    .HasColumnType("date");

                entity.Property(e => e.Itemlistid).HasColumnName("itemlistid");

                entity.Property(e => e.Totalexpense).HasColumnName("totalexpense");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Itemlist)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.Itemlistid)
                    .HasConstraintName("FK__expenses__itemli__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__expenses__userID__4222D4EF");
            });

            modelBuilder.Entity<ItemList>(entity =>
            {
                entity.ToTable("itemList");

                entity.Property(e => e.Itemlistid).HasColumnName("itemlistid");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemList)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__itemList__itemid__3A81B327");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__items__56A1284AE5DA8944");

                entity.ToTable("items");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Itembill).HasColumnName("itembill");

                entity.Property(e => e.Itemcost).HasColumnName("itemcost");

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.LoginId)
                    .HasColumnName("loginID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__CB9A1CDF7FB5DC9C");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId)
                    .HasColumnName("loginID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .IsRequired()
                    .HasColumnName("phoneno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Useraddress)
                    .IsRequired()
                    .HasColumnName("useraddress")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__users__loginID__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
