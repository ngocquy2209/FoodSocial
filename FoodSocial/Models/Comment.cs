using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodSocial.Models
{
    [Table("tblCOMMENT")]
    public class Comment
    {
        [Key]
        public int idComment { set; get; }
        public int idBaiDang { set; get; }
        public string idNguoiViet { get; set; }
        public string tenNguoiViet { get; set; }
        public int idAvatar { get; set; }
        public string noiDung { get; set; }
        public DateTime thoiGianViet { get; set; }
        [ForeignKey("idBaiDang")]
        public virtual BaiChiaSe BaiChiaSe { set; get; }
    }
}