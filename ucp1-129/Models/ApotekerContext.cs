using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ucp1_129.Models
{
    public partial class ApotekerContext : DbContext
    {
        public ApotekerContext()
        {
        }

        public ApotekerContext(DbContextOptions<ApotekerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kasir> Kasir { get; set; }
        public virtual DbSet<Obat> Obat { get; set; }
        public virtual DbSet<Pegawai> Pegawai { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Pesan> Pesan { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kasir>(entity =>
            {
                entity.HasKey(e => e.IdKasir);

                entity.Property(e => e.IdKasir).HasColumnName("id_Kasir");

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Umur)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Obat>(entity =>
            {
                entity.HasKey(e => e.IdObat);

                entity.Property(e => e.IdObat)
                    .HasColumnName("Id_Obat")
                    .ValueGeneratedNever();

                entity.Property(e => e.Harga)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaObat)
                    .HasColumnName("Nama_Obat")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pegawai>(entity =>
            {
                entity.HasKey(e => e.IdPegawai);

                entity.Property(e => e.IdPegawai)
                    .HasColumnName("Id_Pegawai")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPegawai)
                    .HasColumnName("Nama_Pegawai")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Umur)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli).HasColumnName("ID_Pembeli");

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Umur)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pesan>(entity =>
            {
                entity.HasKey(e => e.IdPesanan);

                entity.Property(e => e.IdPesanan)
                    .HasColumnName("Id_Pesanan")
                    .ValueGeneratedNever();

                entity.Property(e => e.Harga)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaObat)
                    .HasColumnName("Nama_Obat")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
