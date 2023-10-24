using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartWatch_MVC.Models
{
    public partial class QLBanDongHoContext : DbContext
    {
        public QLBanDongHoContext()
        {
        }

        public QLBanDongHoContext(DbContextOptions<QLBanDongHoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; } = null!;
        public virtual DbSet<TAnhSp> TAnhSps { get; set; } = null!;
        public virtual DbSet<TChatLieu> TChatLieus { get; set; } = null!;
        public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; } = null!;
        public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; } = null!;
        public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; } = null!;
        public virtual DbSet<THangSx> THangSxes { get; set; } = null!;
        public virtual DbSet<THoaDonBan> THoaDonBans { get; set; } = null!;
        public virtual DbSet<TKhachHang> TKhachHangs { get; set; } = null!;
        public virtual DbSet<TKichThuoc> TKichThuocs { get; set; } = null!;
        public virtual DbSet<TLoaiDt> TLoaiDts { get; set; } = null!;
        public virtual DbSet<TLoaiSp> TLoaiSps { get; set; } = null!;
        public virtual DbSet<TMauSac> TMauSacs { get; set; } = null!;
        public virtual DbSet<TNhanVien> TNhanViens { get; set; } = null!;
        public virtual DbSet<TQuocGium> TQuocGia { get; set; } = null!;
        public virtual DbSet<TUser> TUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-1SOFRQ1F\\TUNGLE;Initial Catalog=QLBanDongHo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAnhChiTietSp>(entity =>
            {
                entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh });

                entity.ToTable("tAnhChiTietSP");

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.TenFileAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TAnhSp>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.TenFileAnh });

                entity.ToTable("tAnhSP");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength();

                entity.Property(e => e.TenFileAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TChatLieu>(entity =>
            {
                entity.HasKey(e => e.MaChatLieu);

                entity.ToTable("tChatLieu");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChatLieu).HasMaxLength(150);
            });

            modelBuilder.Entity<TChiTietHdb>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp });

                entity.ToTable("tChiTietHDB");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.GhiChu).HasMaxLength(100);
            });

            modelBuilder.Entity<TChiTietSanPham>(entity =>
            {
                entity.HasKey(e => e.MaChiTietSp);

                entity.ToTable("tChiTietSanPham");

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaKichThuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength();

                entity.Property(e => e.Slton).HasColumnName("SLTon");

                entity.Property(e => e.Video)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TDanhMucSp>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("tDanhMucSP");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GiaLonNhat).HasColumnType("money");

                entity.Property(e => e.GiaNhoNhat).HasColumnType("money");

                entity.Property(e => e.GioiThieuSp)
                    .HasMaxLength(255)
                    .HasColumnName("GioiThieuSP");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDacTinh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNuocSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaNuocSX")
                    .IsFixedLength();

                entity.Property(e => e.Model).HasMaxLength(55);

                entity.Property(e => e.NganLapTop).HasMaxLength(55);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(150)
                    .HasColumnName("TenSP");

                entity.Property(e => e.Website)
                    .HasMaxLength(155)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<THangSx>(entity =>
            {
                entity.HasKey(e => e.MaHangSx);

                entity.ToTable("tHangSX");

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.HangSx)
                    .HasMaxLength(100)
                    .HasColumnName("HangSX");

                entity.Property(e => e.MaNuocThuongHieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<THoaDonBan>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("tHoaDonBan");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");

                entity.Property(e => e.ThongTinThue).HasMaxLength(250);

                entity.Property(e => e.TongTienHd)
                    .HasColumnType("money")
                    .HasColumnName("TongTienHD");
            });

            modelBuilder.Entity<TKhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhanhHang);

                entity.ToTable("tKhachHang");

                entity.Property(e => e.MaKhanhHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenKhachHang).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TKichThuoc>(entity =>
            {
                entity.HasKey(e => e.MaKichThuoc);

                entity.ToTable("tKichThuoc");

                entity.Property(e => e.MaKichThuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KichThuoc)
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TLoaiDt>(entity =>
            {
                entity.HasKey(e => e.MaDt);

                entity.ToTable("tLoaiDT");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.TenLoai).HasMaxLength(100);
            });

            modelBuilder.Entity<TLoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("tLoaiSP");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Loai).HasMaxLength(100);
            });

            modelBuilder.Entity<TMauSac>(entity =>
            {
                entity.HasKey(e => e.MaMauSac);

                entity.ToTable("tMauSac");

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenMauSac).HasMaxLength(100);
            });

            modelBuilder.Entity<TNhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.ToTable("tNhanVien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

             

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TQuocGium>(entity =>
            {
                entity.HasKey(e => e.MaNuoc);

                entity.ToTable("tQuocGia");

                entity.Property(e => e.MaNuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNuoc).HasMaxLength(100);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("tUser");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
