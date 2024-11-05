using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace template.api.postgres.data.Models;

public partial class DbtemplateRestContext : DbContext
{
    public DbtemplateRestContext()
    {
    }

    public DbtemplateRestContext(DbContextOptions<DbtemplateRestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCompany> TbCompanies { get; set; }

    public virtual DbSet<TbTokenBearer> TbTokenBearers { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=DBTemplateRest;Username=UsrTemplateRest;Password=Dela12ka@");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TbCompanies_pkey");

            entity.Property(e => e.Address).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UserCreated).HasMaxLength(100);
            entity.Property(e => e.UserModifield).HasMaxLength(100);
        });

        modelBuilder.Entity<TbTokenBearer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TbTokenBearers_pkey");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TbUsers_pkey");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.UserCreated).HasMaxLength(100);
            entity.Property(e => e.UserModified).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
