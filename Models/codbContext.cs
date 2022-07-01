using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CEROK_STAJ_WEB.Models
{
    public partial class codbContext : DbContext
    {
        public codbContext()
        {
        }

        public codbContext(DbContextOptions<codbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Doktor> Doktors { get; set; } = null!;
        public virtual DbSet<Doktor_Poli> Doktor_Polis { get; set; } = null!;
        public virtual DbSet<Hastane> Hastanes { get; set; } = null!;
        public virtual DbSet<Hastane_poli> Hastane_polis { get; set; } = null!;
        public virtual DbSet<Hasta> Hastas { get; set; } = null!;
        public virtual DbSet<Il> Ils { get; set; } = null!;
        public virtual DbSet<Ilce> Ilces { get; set; } = null!;
        public virtual DbSet<Poliklinik> Polikliniks { get; set; } = null!;
        public virtual DbSet<RandevuKismi> RandevuKismis { get; set; } = null!;
        public virtual DbSet<Rapor> Rapors { get; set; } = null!;
        public virtual DbSet<Recete> Recetes { get; set; } = null!;
        public virtual DbSet<Tani> Tanis { get; set; } = null!;
        public virtual DbSet<Tetkik> Tetkiks { get; set; } = null!;
        public virtual DbSet<RandevuTetkik> RandevuTetkiks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=codb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktor>(entity =>
            {
                entity.ToTable("Doktor");

                entity.Property(e => e.doktorismi).HasMaxLength(50);

                entity.Property(e => e.doktorpassword).HasMaxLength(50);

                entity.Property(e => e.doktorsoyismi).HasMaxLength(50);
            });

            modelBuilder.Entity<Doktor_Poli>(entity =>
            {
                entity.ToTable("Doktor_Poli");

                entity.HasOne(d => d.bolum)
                    .WithMany(p => p.Doktor_Polis)
                    .HasForeignKey(d => d.bolumID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doktor_Poli_Poliklinik");

                entity.HasOne(d => d.doktor)
                    .WithMany(p => p.Doktor_Polis)
                    .HasForeignKey(d => d.doktorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doktor_Poli_Doktor");
            });

            modelBuilder.Entity<Hastane>(entity =>
            {
                entity.ToTable("Hastane");

                entity.Property(e => e.hastaneIsim).HasMaxLength(90);

                entity.HasOne(d => d.ilce)
                    .WithMany(p => p.Hastanes)
                    .HasForeignKey(d => d.ilceID)
                    .HasConstraintName("FK_Hastane_Ilce");
            });

            modelBuilder.Entity<Hastane_poli>(entity =>
            {
                entity.ToTable("Hastane_poli");

                entity.HasOne(d => d.bolum)
                    .WithMany(p => p.Hastane_polis)
                    .HasForeignKey(d => d.bolumID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hastane_poli_Poliklinik");

                entity.HasOne(d => d.hastane)
                    .WithMany(p => p.Hastane_polis)
                    .HasForeignKey(d => d.hastaneID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hastane_poli_Hastane");
            });

            modelBuilder.Entity<Hasta>(entity =>
            {
                entity.ToTable("Hasta");
                entity.HasKey(e => e.hastaID);

                entity.Property(e => e.cinsiyet).HasMaxLength(5);

                entity.Property(e => e.dogumTarihi).HasColumnType("date");

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.isim).HasMaxLength(50);

                entity.Property(e => e.kanGrubu).HasMaxLength(5);

                entity.Property(e => e.sifre).HasMaxLength(50);

                entity.Property(e => e.soyad).HasMaxLength(50);

                entity.Property(e => e.tc).HasMaxLength(50);

                entity.Property(e => e.telefonNo).HasMaxLength(15);
            });

            modelBuilder.Entity<Il>(entity =>
            {
                entity.HasKey(e => e.ilKodu);

                entity.ToTable("Il");

                entity.Property(e => e.ilIsmi).HasMaxLength(50);
            });

            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.ToTable("Ilce");

                entity.Property(e => e.ilceIsmi).HasMaxLength(50);

                entity.HasOne(d => d.ilKoduNavigation)
                    .WithMany(p => p.Ilces)
                    .HasForeignKey(d => d.ilKodu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilce_Il");
            });

            modelBuilder.Entity<Poliklinik>(entity =>
            {
                entity.HasKey(e => e.bolumID);

                entity.ToTable("Poliklinik");

                entity.Property(e => e.bolumIsmi).HasMaxLength(50);
            });

            modelBuilder.Entity<RandevuKismi>(entity =>
            {
                entity.HasKey(e => e.randevuID);

                entity.ToTable("RandevuKismi");

                entity.Property(e => e.gunsaat);
                    //.IsRowVersion()
                    //.IsConcurrencyToken();

                entity.HasOne(d => d.doktor)
                    .WithMany(p => p.RandevuKismis)
                    .HasForeignKey(d => d.doktorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RandevuKismi_Doktor");

                entity.HasOne(d => d.hasta)
                    .WithMany(p => p.RandevuKismis)
                    .HasForeignKey(d => d.hastaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RandevuKismi_Hasta");
            });

            modelBuilder.Entity<Rapor>(entity =>
            {
                entity.ToTable("Rapor");

                entity.Property(e => e.gunsaat);
                    //.IsRowVersion()
                    //.IsConcurrencyToken();

                entity.HasOne(d => d.tani)
                    .WithMany(p => p.Rapors)
                    .HasForeignKey(d => d.taniID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rapor_Tani");
            });

            modelBuilder.Entity<Recete>(entity =>
            {
                entity.ToTable("Recete");

                entity.Property(e => e.receteID).ValueGeneratedNever();

                entity.Property(e => e.doktorID).ValueGeneratedOnAdd();

                entity.Property(e => e.gunsaat)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.doktor)
                    .WithMany(p => p.Recetes)
                    .HasForeignKey(d => d.doktorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recete_Doktor");

                entity.HasOne(d => d.hasta)
                    .WithMany(p => p.Recetes)
                    .HasForeignKey(d => d.hastaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recete_Hasta");

                entity.HasOne(d => d.randevu)
                    .WithMany(p => p.Recetes)
                    .HasForeignKey(d => d.randevuID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recete_RandevuKismi");
            });

            modelBuilder.Entity<Tani>(entity =>
            {
                entity.ToTable("Tani");

                entity.Property(e => e.taniAciklama).HasMaxLength(200);

                entity.Property(e => e.tarih)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.doktor)
                    .WithMany(p => p.Tanis)
                    .HasForeignKey(d => d.doktorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tani_Doktor");

                entity.HasOne(d => d.hasta)
                    .WithMany(p => p.Tanis)
                    .HasForeignKey(d => d.hastaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tani_Hasta");

                entity.HasOne(d => d.randevu)
                    .WithMany(p => p.Tanis)
                    .HasForeignKey(d => d.randevuID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tani_RandevuKismi");
            });

            modelBuilder.Entity<Tetkik>(entity =>
            {
                entity.ToTable("Tetkik");

                entity.Property(e => e.tetkikAyrinti).HasMaxLength(200);
               


                

                


            });
            modelBuilder.Entity<RandevuTetkik>(entity =>
            {
                entity.ToTable("RandevuTetkik");
                entity.Property(e => e.Sonuc).HasMaxLength(400);
                entity.Property(e => e.IsChecked).HasDefaultValue(null);
                entity.HasOne(d => d.Randevu)
                    .WithMany(p => p.RandevuTetkiks)
                    .HasForeignKey(d => d.RandevuID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RandevuTetkik_RandevuKismi");
                entity.HasOne(d => d.Tetkik)
                    .WithMany(p => p.RandevuTetkiks)
                    .HasForeignKey(d => d.TetkikID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RandevuTetkik_Tetkik");

            });

            OnModelCreatingPartial(modelBuilder);
        }
        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
