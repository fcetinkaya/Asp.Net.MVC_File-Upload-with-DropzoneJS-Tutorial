using AspNetMvc_Fileupload_DropzoneJs.Context;
using AspNetMvc_Fileupload_DropzoneJs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc_Fileupload_DropzoneJs.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        public ActionResult Search(string keyword)
        {
            List<Product> products = db.Products.Include("Category")
                .Where(x =>
                    x.Name.Contains(keyword) ||
                    x.Category.Name.Contains(keyword) ||
                    x.Amount.ToString().Contains(keyword) ||
                    x.Price.ToString().Contains(keyword))
                .ToList();

            return View("Index", products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddImages(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost] // for multiupload use '[]'
        public ActionResult UploadProductImages(int id, HttpPostedFileBase[] productpictures)
        {
            string uploadFullPath = Server.MapPath("/Uploads");
            foreach (var pp in productpictures)
            {
                //image/jpeg
                string ext = pp.ContentType.Split('/')[1];
                ProductPicture productPicture = new ProductPicture();
                string filename = $"f_{productPicture.Id}.{ext}";  //f_1d1d1d-ddd.png
                string fullFilePath = uploadFullPath + "/" + filename;
                pp.SaveAs(fullFilePath);


                productPicture.FileName = filename;
                productPicture.ProductId = id;

                db.ProductPictures.Add(productPicture);
                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult GetProductImages(int id)
        {
            List<ProductPicture> productPictures = db.ProductPictures.Where(x => x.ProductId == id).ToList();
            return PartialView("_ProductPictures", productPictures);
        }
        public ActionResult RemoveProductPicture(Guid id)
        {
            db.ProductPictures.Remove(db.ProductPictures.Find(id));
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
