using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class TravelixContext : DbContext
    {
        public TravelixContext()
        {
        }

        public TravelixContext(DbContextOptions<TravelixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dattour> Dattours { get; set; }
        public virtual DbSet<Diadiem> Diadiems { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Quanly> Quanlies { get; set; }
        public virtual DbSet<Taikhoanquanly> Taikhoanquanlies { get; set; }
        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-517BT7F\\SQLEXPRESS; Database = Travelix; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dattour>(entity =>
            {
                entity.HasKey(e => e.IdDatTour);

                entity.ToTable("DATTOUR");

                entity.Property(e => e.IdDatTour)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_DatTour");

                entity.Property(e => e.IdKhachHang).HasColumnName("ID_KhachHang");

                entity.Property(e => e.IdTour).HasColumnName("ID_Tour");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.Dattours)
                    .HasForeignKey(d => d.IdKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DATTOUR_KHACHHANG");

                entity.HasOne(d => d.IdTourNavigation)
                    .WithMany(p => p.Dattours)
                    .HasForeignKey(d => d.IdTour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DATTOUR_TOUR");
            });

            modelBuilder.Entity<Diadiem>(entity =>
            {
                entity.HasKey(e => e.IdDiaDiem);

                entity.ToTable("DIADIEM");

                entity.Property(e => e.IdDiaDiem)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_DiaDiem");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.IdKhachHang);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.IdKhachHang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_KhachHang");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.MatKhau).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai).HasMaxLength(10);

                entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            });

            modelBuilder.Entity<Quanly>(entity =>
            {
                entity.HasKey(e => e.IdQuanLy);

                entity.ToTable("QUANLY");

                entity.Property(e => e.IdQuanLy)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_QuanLy");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.SoDienThoai).HasMaxLength(10);

                entity.Property(e => e.TenQuanLy).HasMaxLength(200);
            });

            modelBuilder.Entity<Taikhoanquanly>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TAIKHOANQUANLY");

                entity.Property(e => e.IdQuanLy).HasColumnName("ID_QuanLy");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdQuanLyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdQuanLy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAIKHOANQUANLY_QUANLY");
            });

            modelBuilder.Entity<Thanhtoan>(entity =>
            {
                entity.HasKey(e => e.IdThanhToan);

                entity.ToTable("THANHTOAN");

                entity.Property(e => e.IdThanhToan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ThanhToan");

                entity.Property(e => e.HinhThuc).HasMaxLength(100);

                entity.Property(e => e.IdDatTour).HasColumnName("ID_DatTour");

                entity.HasOne(d => d.IdDatTourNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.IdDatTour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THANHTOAN_DATTOUR");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.HasKey(e => e.IdTinTuc);

                entity.ToTable("TINTUC");

                entity.Property(e => e.IdTinTuc)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TinTuc");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.HasKey(e => e.IdTour);

                entity.ToTable("TOUR");

                entity.Property(e => e.IdTour)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Tour");

                entity.Property(e => e.HuongDanVien).HasMaxLength(100);

                entity.Property(e => e.IdDiaDiem).HasColumnName("ID_DiaDiem");

                entity.Property(e => e.PhuongTien).HasMaxLength(100);

                entity.HasOne(d => d.IdDiaDiemNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.IdDiaDiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TOUR_DIADIEM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
