using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApdAPI.Models;

public partial class ApdDbContext : DbContext
{
    public ApdDbContext()
    {
    }

    public ApdDbContext(DbContextOptions<ApdDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnsiedadTest> AnsiedadTests { get; set; }

    public virtual DbSet<DepresionTest> DepresionTests { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnsiedadTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ansiedad__3214EC0739FC627A");

            entity.ToTable("AnsiedadTest");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepresionTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Depresio__3214EC073DC2B567");

            entity.ToTable("DepresionTest");

            entity.Property(e => e.AlcoholOdrogas).HasColumnName("AlcoholODrogas");
            entity.Property(e => e.AmigoOfamiliarConfianza).HasColumnName("AmigoOFamiliarConfianza");
            entity.Property(e => e.AoFconfianzaHablar).HasColumnName("AoFConfianzaHablar");
            entity.Property(e => e.ApoyoUtilAhora).HasMaxLength(1000);
            entity.Property(e => e.CansancioOfatiga).HasColumnName("CansancioOFatiga");
            entity.Property(e => e.ComoTeHasSentido).HasMaxLength(1000);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FrecuenciaConsumoD).HasMaxLength(1000);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.ObjetivosParaMejorar).HasMaxLength(1000);
            entity.Property(e => e.OtrosAspectoDeSalud).HasMaxLength(1000);
            entity.Property(e => e.PensamientosOdeseosSuicidas).HasColumnName("PensamientosODeseosSuicidas");
            entity.Property(e => e.PropositoUsoApp).HasMaxLength(1000);
            entity.Property(e => e.QueDiagnostico).HasMaxLength(1000);
            entity.Property(e => e.QueMedicamentos).HasMaxLength(1000);
            entity.Property(e => e.QueTeDetiene).HasMaxLength(1000);
            entity.Property(e => e.SintomasFisicos).HasMaxLength(1000);
            entity.Property(e => e.SituacionEventoQueAfecta).HasMaxLength(1000);
            entity.Property(e => e.TipoDeSustancias).HasMaxLength(1000);
            entity.Property(e => e.TipoDeTratamiento).HasMaxLength(1000);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sessions__3214EC077949C494");

            entity.Property(e => e.AccessToken).HasMaxLength(512);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiresAt).HasColumnType("datetime");
            entity.Property(e => e.RefreshToken).HasMaxLength(512);

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sessions__UserId__5FB337D6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C572FCFD");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053424CC5114").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(64);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
