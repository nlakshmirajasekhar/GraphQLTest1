using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQLTest1.Models
{
    public partial class inventory1Context : DbContext
    {
        public inventory1Context()
        {
        }

        public inventory1Context(DbContextOptions<inventory1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemGroups> ItemGroups { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Materialmanagement> Materialmanagement { get; set; }
        public virtual DbSet<PriceList> PriceList { get; set; }
        public virtual DbSet<Purchaseheader> Purchaseheader { get; set; }
        public virtual DbSet<Purchaselines> Purchaselines { get; set; }
        public virtual DbSet<Salesheader> Salesheader { get; set; }
        public virtual DbSet<Saleslines> Saleslines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=RAJATHEGREAT\\SQLEXPRESS;Database=inventory1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemGroups>(entity =>
            {
                entity.HasKey(e => e.Grpid)
                    .HasName("PK__ItemGrou__DE43D10045098C27");

                entity.Property(e => e.Grpname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Maingrp)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK__Items__727D8793F3F0AC7F");

                entity.Property(e => e.Grpid).HasColumnName("grpid");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uom)
                    .HasColumnName("uom")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grp)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Grpid)
                    .HasConstraintName("FK__Items__grpid__38996AB5");
            });

            modelBuilder.Entity<Materialmanagement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("materialmanagement");

                entity.Property(e => e.Qntyin).HasColumnName("qntyin");

                entity.Property(e => e.Qntyout).HasColumnName("qntyout");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.Property(e => e.Traid).HasColumnName("traid");

                entity.Property(e => e.Transno)
                    .HasColumnName("transno")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Tratype).HasColumnName("tratype");
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("priceList");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.Itemid)
                    .HasConstraintName("FK__priceList__itemi__3A81B327");
            });

            modelBuilder.Entity<Purchaseheader>(entity =>
            {
                entity.HasKey(e => e.Mir)
                    .HasName("PK__purchase__C797349CFA8B2410");

                entity.ToTable("purchaseheader");

                entity.Property(e => e.Mir).HasColumnName("MIR");

                entity.Property(e => e.Baseamt).HasColumnName("baseamt");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Suppliername)
                    .HasColumnName("suppliername")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Taxes).HasColumnName("taxes");

                entity.Property(e => e.Totalamt).HasColumnName("totalamt");
            });

            modelBuilder.Entity<Purchaselines>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("purchaselines");

                entity.Property(e => e.Item)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mir).HasColumnName("mir");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.HasOne(d => d.MirNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Mir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchaselin__mir__3E52440B");
            });

            modelBuilder.Entity<Salesheader>(entity =>
            {
                entity.HasKey(e => e.Billno)
                    .HasName("PK__saleshea__11F388317FB8AA0F");

                entity.ToTable("salesheader");

                entity.Property(e => e.Baseamt).HasColumnName("baseamt");

                entity.Property(e => e.Customername)
                    .HasColumnName("customername")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Taxes).HasColumnName("taxes");

                entity.Property(e => e.Totalamt).HasColumnName("totalamt");
            });

            modelBuilder.Entity<Saleslines>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("saleslines");

                entity.Property(e => e.Billno).HasColumnName("billno");

                entity.Property(e => e.Item)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Rat).HasColumnName("rat");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.HasOne(d => d.BillnoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Billno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__salesline__billn__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
