using FoodSocial.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodSocial.Controllers
{
    public class TrangNguoiDungController : Controller
    {
        //
        // GET: /TrangNguoiDung/
        DataContext datacontext = new DataContext();
        public ActionResult TrangChu()
        {
            ViewBag.ChiaSe = datacontext.BaiChiaSes.ToList();
            return View();
        }
        public ActionResult DangNhap(FormCollection form)
        {
            Session["tenDangNhap"] = form["User"];
            Session["id"] = form["id"];
            return RedirectToAction("TrangChu");
        }
        public ActionResult ChiaSeAnUong()
        {
            return View();
        }
        public JsonResult AnhMinhHoa(string linkCu)
        {
            string link = "";
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var fileName = String.Format("{0:ddMMyyyyhhmmss}", DateTime.Today) + Path.GetFileName(fileContent.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                        fileContent.SaveAs(path);
                        link = "/Images/" + fileName;
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }
            return Json(link);
        }
        [ValidateInput(false)]
        public ActionResult ChiaSe(FormCollection form)
        {
            BaiChiaSe CS = new BaiChiaSe();
            CS.idNguoiViet = Session["id"].ToString();
            CS.noiDung = form["NoiDung"];
            CS.tenNguoiViet = Session["tenDangNhap"].ToString();
            CS.thoiGianViet = DateTime.Now;
            CS.diaDiem = form["DiaDiem"];
            CS.linkAnh = form["linkAnh"];
            CS.vote = 0;
            datacontext.BaiChiaSes.Add(CS);
            datacontext.SaveChanges();
            return RedirectToAction("TrangChu");
        }
        public JsonResult Vote(int idBaiViet)
        {
            BaiChiaSe CS = datacontext.BaiChiaSes.SingleOrDefault(x => x.idBaiDang == idBaiViet);
            CS.vote += 1;
            datacontext.SaveChanges();
            return Json(CS.vote+" Vote", JsonRequestBehavior.AllowGet);
        }
        public ActionResult LayNoiDungBL(int idBaiViet)
        {
            ViewBag.idBaiViet = idBaiViet;
            return View("_ViewBinhLuan", datacontext.Comments.Where(x => x.idBaiDang == idBaiViet).ToList());
        }
        public ActionResult BinhLuan(int idBaiViet)
        {
            ViewBag.idBaiViet = idBaiViet;
            return View("_BinhLuan");
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LuuBinhLuan(FormCollection form)
        {
            int idBV = Convert.ToInt32(form["idBaiViet"]);
            string BL = form["BinhLuan"].Substring(1, form["BinhLuan"].Length-1);
            if (BL != "")
            {
                Comment CM = new Comment();
                CM.idNguoiViet = Session["id"].ToString();
                CM.noiDung = BL;
                CM.tenNguoiViet = Session["tenDangNhap"].ToString();
                CM.thoiGianViet = DateTime.Now;
                CM.idBaiDang = idBV;
                CM.vote = 0;
                CM.idAvatar = 0;
                datacontext.Comments.Add(CM);
                datacontext.SaveChanges();
            }
            return LayNoiDungBL(idBV);
        }
    }
}
