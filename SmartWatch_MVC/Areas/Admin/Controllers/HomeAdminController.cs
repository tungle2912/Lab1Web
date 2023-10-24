using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartWatch_MVC.Models;
using X.PagedList;

namespace SmartWatch_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLBanDongHoContext db= new QLBanDongHoContext();
        [Route("")]
        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),"MaChatLieu","ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(),"MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(),"MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),"MaLoai", "Loai");
            ViewBag.MaDacTinh = new SelectList(db.TLoaiDts.ToList(),"MaDt", "TenLoai");

            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham); 
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
           
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSX = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDacTinh = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                //db.Update(sanPham);
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");
            }
            return View(sanPham);

        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            //thông báo cho người dùng biết có xóa được hay không 
            TempData["Message"] = "";// để khi chuyển hướng vấn giữ được giá trị
            //kiểm tra chi tiết sản phẩm có tồn tại mã sản phẩm này ko
            var chitietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if (chitietSanPham.Count > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                //nếu đã có trong chi tiết thì sẽ đưa về danh mục sản phẩm
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            // ngược lại thì xóa ảnh và danh mục sản phẩm vì , ảnh là bên nhiều
            var anhSanPham = db.TAnhSps.Where(x=>x.MaSp==maSanPham).ToList();
            //nếu tồn tại ảnh sản phảm thì xóa 
            if (anhSanPham.Any())
            {
                //xóa một lúc nhiều bản ghi
                db.RemoveRange(anhSanPham); 
            }
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Xóa sản phẩm thành công";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");         
        }

       

    

        //danh sách khác hàng
        [Route("DanhMucKhachHang")]
        public IActionResult DanhMucKhachHang(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstKhachHang = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang);
            PagedList<TKhachHang> lst = new PagedList<TKhachHang>(lstKhachHang, pageNumber, pageSize);
            return View(lst);
        }

        //danh muc nhân viên 
        [Route("DanhMucNhanVien")]
        public IActionResult DanhMucNhanVien(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstNhanVien = db.TNhanViens.AsNoTracking().OrderBy(x => x.TenNhanVien);
            PagedList<TNhanVien> lst = new PagedList<TNhanVien>(lstNhanVien, pageNumber, pageSize);
            return View(lst);
        }


        //thêm nhân viên mới 
        [Route("ThemNhanVienMoi")]
        [HttpGet]
        public IActionResult ThemNhanVienMoi()
        {
            
            return View();
        }

        [Route("ThemNhanVienMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVienMoi(TNhanVien nhanVien)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                db.TNhanViens.Add(nhanVien);
                db.SaveChanges();
                TempData["Message"] = "Thêm thành công";
                return RedirectToAction("DanhMucNhanVien");
                
            }
            TempData["Message"] = "Thêm không thành công";
            return View(nhanVien);

        }

        [Route("SuaNhanVien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string maNhanVien)
        {       
            var nhanVien= db.TNhanViens.Find(maNhanVien);
            return View(nhanVien);
        }

        [Route("SuaNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(TNhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                //db.Update(nhanVien); dùng cái này cùng được 
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucNhanVien", "HomeAdmin");
            }
            return View(nhanVien);

        }


        // hoa đơn
        [Route("DanhMucHoaDon")]
        public IActionResult DanhMucHoaDon(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var query = from hd in db.THoaDonBans
                        join cthd in db.TChiTietHdbs on hd.MaHoaDon equals cthd.MaHoaDon
                        join ctsp in db.TChiTietSanPhams on cthd.MaChiTietSp equals ctsp.MaChiTietSp
                        join sp in db.TDanhMucSps on ctsp.MaSp equals sp.MaSp
                        select new HoaDonViewModel
                        {
                            HoaDon = hd,
                            ChiTietHdb = cthd,
                            ChiTietSanPham = ctsp,
                            DanhMucSanPham = sp
                        };

            var lst = query.AsNoTracking()
                .OrderBy(x => x.HoaDon.MaHoaDon)
                .ToPagedList(pageNumber, pageSize);

            return View(lst);
        }


    

        

        [Route("SuaHoaDon")]
        [HttpGet]
        public IActionResult SuaHoaDon(string maHoaDon)
        {
       
            var hoadon = db.THoaDonBans.Find(maHoaDon);
            return View(hoadon);
        }

        [Route("SuaHoaDon")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaHoaDon(THoaDonBan hoadon)
        {
            if (ModelState.IsValid)
            {
                //db.Update(sanPham);
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucHoaDon", "HomeAdmin");
            }
            return View(hoadon);

        }

        [Route("XoaHoaDon")]
        [HttpGet]
        public IActionResult XoaHoaDon(string maHoaDon)
        {
            //thông báo cho người dùng biết có xóa được hay không 
            TempData["Message"] = "";// để khi chuyển hướng vấn giữ được giá trị
            //kiểm tra chi tiết sản phẩm có tồn tại mã sản phẩm này ko
            var chitietHoaDon = db.TChiTietHdbs.Where(x => x.MaHoaDon == maHoaDon).ToList();
            if (chitietHoaDon.Count > 0)
            {
                TempData["Message"] = "Không xóa được hóa đơn này";
                //nếu đã có trong chi tiết thì sẽ đưa về danh mục sản phẩm
                return RedirectToAction("DanhMucHoaDon", "HomeAdmin");
            }
            // ngược lại thì xóa ảnh và danh mục sản phẩm vì , ảnh là bên nhiều
        
            db.Remove(db.THoaDonBans.Find(maHoaDon));
            db.SaveChanges();
            TempData["Message"] = "Xóa hóa đơn thành công";
            return RedirectToAction("DanhMucHoaDon", "HomeAdmin");
        }

    }
}
