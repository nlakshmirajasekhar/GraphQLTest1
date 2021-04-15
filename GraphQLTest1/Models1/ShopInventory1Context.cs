using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQLTest1.Models1
{
    public partial class ShopInventory1Context : DbContext
    {
        public ShopInventory1Context()
        {
        }

        public ShopInventory1Context(DbContextOptions<ShopInventory1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Itemgroups> Itemgroups { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Materialmanagement> Materialmanagement { get; set; }
        public virtual DbSet<Pricelist> Pricelist { get; set; }
        public virtual DbSet<Purchasesheader> Purchasesheader { get; set; }
        public virtual DbSet<Purchaseslines> Purchaseslines { get; set; }
        public virtual DbSet<Salesheader> Salesheader { get; set; }
        public virtual DbSet<Saleslines> Saleslines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=RAJATHEGREAT\\SQLEXPRESS;Database=ShopInventory1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Itemgroups>(entity =>
            {
                entity.HasKey(e => e.Grpid)
                    .HasName("PK__itemgrou__1C8985ACC3B5AF35");

                entity.ToTable("itemgroups");

                entity.Property(e => e.Grpid).HasColumnName("grpid");

                entity.Property(e => e.Grpname)
                    .HasColumnName("grpname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Maingrp)
                    .HasColumnName("maingrp")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK__items__56A22C92759E59AF");

                entity.ToTable("items");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Grpid).HasColumnName("grpid");

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uom)
                    .HasColumnName("uom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grp)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Grpid)
                    .HasConstraintName("FK__items__grpid__38996AB5");
            });

            modelBuilder.Entity<Materialmanagement>(entity =>
            {
                entity.HasKey(e => e.Transno)
                    .HasName("PK__material__DB1E1CD857336D4C");

                entity.ToTable("materialmanagement");

                entity.Property(e => e.Transno).HasColumnName("transno");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Qtyin).HasColumnName("qtyin");

                entity.Property(e => e.Qtyout).HasColumnName("qtyout");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Traid).HasColumnName("traid");

                entity.Property(e => e.Tratype).HasColumnName("tratype");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Materialmanagement)
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__materialm__itemi__4BAC3F29");
            });

            modelBuilder.Entity<Pricelist>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK__pricelis__56A22C9254F0E4CB");

                entity.ToTable("pricelist");

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.Pricelist)
                    .HasForeignKey<Pricelist>(d => d.Itemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item");
            });

            modelBuilder.Entity<Purchasesheader>(entity =>
            {
                entity.HasKey(e => e.Mir)
                    .HasName("PK__purchase__DF5032DE76ADAD2D");

                entity.ToTable("purchasesheader");

                entity.Property(e => e.Mir)
                    .HasColumnName("mir")
                    .ValueGeneratedNever();

                entity.Property(e => e.Baseamt).HasColumnName("baseamt");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purchesesdate)
                    .HasColumnName("purchesesdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Taxes).HasColumnName("taxes");

                entity.Property(e => e.Totamt).HasColumnName("totamt");
            });

            modelBuilder.Entity<Purchaseslines>(entity =>
            {
                entity.HasKey(e => new { e.Mir, e.Sno })
                    .HasName("cominationpk");

                entity.ToTable("purchaseslines");

                entity.Property(e => e.Mir).HasColumnName("mir");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Pitem).HasColumnName("pitem");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.HasOne(d => d.MirNavigation)
                    .WithMany(p => p.Purchaseslines)
                    .HasForeignKey(d => d.Mir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchasesli__mir__412EB0B6");

                entity.HasOne(d => d.PitemNavigation)
                    .WithMany(p => p.Purchaseslines)
                    .HasForeignKey(d => d.Pitem)
                    .HasConstraintName("pitem");
            });

            modelBuilder.Entity<Salesheader>(entity =>
            {
                entity.HasKey(e => e.Billno)
                    .HasName("PK__saleshea__6D9AEEA1F872D886");

                entity.ToTable("salesheader");

                entity.Property(e => e.Billno)
                    .HasColumnName("billno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Baseamt).HasColumnName("baseamt");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salesdate)
                    .HasColumnName("salesdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Taxes).HasColumnName("taxes");

                entity.Property(e => e.Totamt).HasColumnName("totamt");
            });

            modelBuilder.Entity<Saleslines>(entity =>
            {
                entity.HasKey(e => new { e.Billno, e.Sno })
                    .HasName("comination");

                entity.ToTable("saleslines");

                entity.Property(e => e.Billno).HasColumnName("billno");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Itemname).HasColumnName("itemname");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.HasOne(d => d.BillnoNavigation)
                    .WithMany(p => p.Saleslines)
                    .HasForeignKey(d => d.Billno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__salesline__billn__47DBAE45");

                entity.HasOne(d => d.ItemnameNavigation)
                    .WithMany(p => p.Saleslines)
                    .HasForeignKey(d => d.Itemname)
                    .HasConstraintName("itemname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
