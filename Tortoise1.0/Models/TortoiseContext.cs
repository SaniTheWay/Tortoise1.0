using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tortoise1._0.Models;

public partial class TortoiseContext : DbContext
{
    public TortoiseContext()
    {
    }

    public TortoiseContext(DbContextOptions<TortoiseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuyCustomer> BuyCustomers { get; set; }

    public virtual DbSet<BuyFolder> BuyFolders { get; set; }

    public virtual DbSet<SellCustomer> SellCustomers { get; set; }

    public virtual DbSet<SellFolder> SellFolders { get; set; }

    public virtual DbSet<StockMaintain> StockMaintains { get; set; }

    public virtual DbSet<StockType> StockTypes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=HSHLT-1680;Initial Catalog=tortoise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuyCustomer>(entity =>
        {
            entity.ToTable("Buy_Customer");

            entity.Property(e => e.CAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_address");
            entity.Property(e => e.CGstNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_GST_no");
            entity.Property(e => e.CName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_name");
            entity.Property(e => e.CPhone).HasColumnName("c_phone");
        });

        modelBuilder.Entity<BuyFolder>(entity =>
        {
            entity.ToTable("Buy_Folder");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BillNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bill_no");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CheckNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("check_no");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
        });

        modelBuilder.Entity<SellCustomer>(entity =>
        {
            entity.ToTable("Sell_Customer");

            entity.Property(e => e.CAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_address");
            entity.Property(e => e.CGstNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_GST_no");
            entity.Property(e => e.CName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("c_name");
            entity.Property(e => e.CPhone).HasColumnName("c_phone");
        });

        modelBuilder.Entity<SellFolder>(entity =>
        {
            entity.ToTable("Sell_Folder");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BillNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bill_no");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CheckNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("check_no");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
        });

        modelBuilder.Entity<StockMaintain>(entity =>
        {
            entity.ToTable("StockMaintain");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TypeId).HasColumnName("type_id");
        });

        modelBuilder.Entity<StockType>(entity =>
        {
            entity.ToTable("StockType");

            entity.Property(e => e.TName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("T_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
