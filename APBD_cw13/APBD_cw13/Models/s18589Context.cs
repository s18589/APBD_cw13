using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APBD_cw13.Models
{
    public partial class s18589Context : DbContext
    {
        public s18589Context()
        {
        }

        public s18589Context(DbContextOptions<s18589Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieWyrobCukierniczy> ZamowienieWyrobCukierniczy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => e.IdWyrobuCukierniczego)
                    .HasName("WyrobCukierniczy_pk");

                entity.Property(e => e.IdWyrobuCukierniczego).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.DataPrzyjecia).HasColumnType("datetime");

                entity.Property(e => e.DataRealizacji).HasColumnType("datetime");

                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownik");
            });

            modelBuilder.Entity<ZamowienieWyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => new { e.IdWyrobuCukierniczego, e.IdZamowienia })
                    .HasName("Zamowienie_WyrobCukierniczy_pk");

                entity.ToTable("Zamowienie_WyrobCukierniczy");

                entity.Property(e => e.Uwagi)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.IdWyrobuCukierniczegoNavigation)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.IdWyrobuCukierniczego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_2_WyrobCukierniczy");

                entity.HasOne(d => d.IdZamowieniaNavigation)
                    .WithMany(p => p.ZamowienieWyrobCukierniczy)
                    .HasForeignKey(d => d.IdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_2_Zamowienie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
