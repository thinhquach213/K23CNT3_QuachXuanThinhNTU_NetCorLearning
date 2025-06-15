using System.ComponentModel.DataAnnotations;

namespace QxtLesson08.Models
{
    public class QxtAccount
    {
        [Key]
        public int QxtID { get; set; }

        [Display(Name = "Ho Va Ten ")]
        [Required(ErrorMessage = "Họ tên không được để trống.")]
        [StringLength(100)]
        public string QxtFullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string QxtEmail { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string QxtPhone { get; set; }

        [StringLength(200)]
        public string QxtAddress { get; set; }

        [Url(ErrorMessage = "URL ảnh không hợp lệ.")]
        public string QxtAvatar { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime QxtBirthday { get; set; }

        [Required(ErrorMessage = "Giới tính không được để trống.")]
        public string QxtGender { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string QxtPassword { get; set; }

        [Url(ErrorMessage = "URL Facebook không hợp lệ.")]
        public string QxtFacebook { get; set; }
    }
}
