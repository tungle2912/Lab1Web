using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models
{
    public partial class TNhanVien
    {
        public string MaNhanVien { get; set; } = null!;
        public string? Username { get; set; }
        public string? TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? ChucVu { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? GhiChu { get; set; }

        public string? GioiTinh { get; set; }
    }
}
