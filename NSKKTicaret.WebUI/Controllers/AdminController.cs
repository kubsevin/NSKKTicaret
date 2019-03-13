using NSKKTicaret.WebUI.App_Classes;
using NSKKTicaret.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSKKTicaret.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            return View(Context.Connection.Products.ToList());
        }
        public ActionResult AddProduct()
        {
            ViewBag.CategoryList = Context.Connection.Categories.ToList();
            ViewBag.BrandList = Context.Connection.Brands.ToList();
            return View();
        }
        public ActionResult BrandList()
        {
            return View(Context.Connection.Brands.ToList());
        }
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(Brand brn, HttpPostedFileBase fileUpload)
        {
            int pictureId = -1;
            if(fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["BrandWidth"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["BrandHeight"].ToString());
                string name = Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                //string name="/Content/BrandPictures/" +Guid.NewGuid()+ Path.GetExtension(fileUpload.FileName);
                Bitmap bmp = new Bitmap(img, width, height);
                bmp.Save(Server.MapPath(name));

                Picture pic = new Picture();
                pic.MediumPath = name;
                Context.Connection.Pictures.Add(pic);
                Context.Connection.SaveChanges();

                if(pic.id != 0)
                {
                    pictureId = pic.id;
                }
                if (pictureId != -1)
                    brn.PictureID = pictureId;

                Context.Connection.Brands.Add(brn);
                Context.Connection.SaveChanges();
            }
            return RedirectToAction("BrandList");
        }
    }
}