using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodSocial.Models
{
    [Table("tblBAICHIASE")]
    public class BaiChiaSe
    {
        [Key]
        public int idBaiDang { set; get; }
        public string idNguoiViet { get; set; }
        public string tenNguoiViet { get; set; }
        public string noiDung { get; set; }
        public DateTime thoiGianViet { get; set; }
        public int vote { set; get; }
        public string linkAnh { set; get; }
        public string diaDiem { set; get; }
        public string longitude { set; get; }
        public string latitude { set; get; }
        public virtual ICollection<Comment> CacComment { set; get; }
    }
}