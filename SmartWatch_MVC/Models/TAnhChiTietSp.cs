using System;
using System.Collections.Generic;

namespace SmartWatch_MVC.Models
{
    public partial class TAnhChiTietSp
    {
        public string MaChiTietSp { get; set; } = null!;
        public string TenFileAnh { get; set; } = null!;
        public short? ViTri { get; set; }
    }
}
