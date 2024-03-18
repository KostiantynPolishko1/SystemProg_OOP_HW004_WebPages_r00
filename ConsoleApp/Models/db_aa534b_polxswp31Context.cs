﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models;

public partial class db_aa534b_polxswp31Context : DbContext
{
    public db_aa534b_polxswp31Context()
    {
    }

    public db_aa534b_polxswp31Context(DbContextOptions<db_aa534b_polxswp31Context> options)
        : base(options)
    {
    }

    public virtual DbSet<webshortcut> webshortcuts { get; set; }

    public virtual DbSet<webtrack> webtracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql5109.site4now.net;Initial Catalog=db_aa534b_polxswp31;Persist Security Info=True;User ID=db_aa534b_polxswp31_admin;Password=n20ri2J9");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<webshortcut>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_webshortcuts_id");

            entity.HasIndex(e => e.href, "UC_webshortcuts_href").IsUnique();

            entity.HasIndex(e => e.name, "UC_webshortcuts_name").IsUnique();

            entity.Property(e => e.href)
                .IsRequired()
                .HasMaxLength(2083)
                .HasDefaultValueSql("('https://www.google.com/')");
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('Google')");
        });

        modelBuilder.Entity<webtrack>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_webtracks_id");

            entity.Property(e => e.date)
                .HasDefaultValueSql("(TRY_CAST(getdate() AS [date]))")
                .HasColumnType("date");
            entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.owner)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.time).HasDefaultValueSql("(TRY_CONVERT([time],getdate(),(8)))");
            entity.Property(e => e.url)
                .IsRequired()
                .HasMaxLength(2083);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}