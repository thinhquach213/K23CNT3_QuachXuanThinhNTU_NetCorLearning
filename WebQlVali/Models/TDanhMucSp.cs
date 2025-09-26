using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TDanhMucSp
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public int? MaChatLieu { get; set; }

    public string? NganLapTop { get; set; }

    public string? Model { get; set; }

    public double? CanNang { get; set; }

    public string? DoiNoi { get; set; }

    public int? MaHangSx { get; set; }

    public int? MaNuocSx { get; set; }

    public string? MaDacTinh { get; set; }

    public string? Website { get; set; }

    public int? ThoiGianBaoHanh { get; set; }

    public string? GioiThieuSp { get; set; }

    public double? ChietKhau { get; set; }

    public int? MaLoai { get; set; }

    public int? MaDt { get; set; }

    public string? AnhDaiDien { get; set; }

    public decimal? GiaNhoNhat { get; set; }

    public decimal? GiaLonNhat { get; set; }

    public virtual TChatLieu? MaChatLieuNavigation { get; set; }

    public virtual TLoaiDt? MaDtNavigation { get; set; }

    public virtual THangSx? MaHangSxNavigation { get; set; }

    public virtual TLoaiSp? MaLoaiNavigation { get; set; }

    public virtual TQuocGium? MaNuocSxNavigation { get; set; }

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
