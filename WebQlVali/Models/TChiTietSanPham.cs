using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TChiTietSanPham
{
    public int MaChiTietSp { get; set; }

    public int? MaSp { get; set; }

    public int? MaKichThuoc { get; set; }

    public int? MaMauSac { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? Video { get; set; }

    public decimal? DonGiaBan { get; set; }

    public decimal? GiamGia { get; set; }

    public int? Slton { get; set; }

    public virtual TKichThuoc? MaKichThuocNavigation { get; set; }

    public virtual TMauSac? MaMauSacNavigation { get; set; }

    public virtual TDanhMucSp? MaSpNavigation { get; set; }

    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; } = new List<TChiTietHdb>();
}
