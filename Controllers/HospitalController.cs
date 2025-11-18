using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HospitalController : Controller
    {
        HospitalDB _db;
        public HospitalController(HospitalDB db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var Books = _db.Polyclinics;
                   
            return View(Books.ToList());
        }

        //public IActionResult Detail(int id)
        //{

        //    //var Book = _db.Books.Include("Author").ToList().Find(x=>x.BookID==id);
        //    ////var Book = _db.Books.Find(id);

        //    //ViewBag.Categoryler = _db.Book_Category.Include("Category").Where(x => x.BookID == id);

        //    //ViewBag.yorumlar = _db.Yorumlar.Include("Member").Where(x=>x.BookID==id).OrderByDescending(x=>x.YorumTarih).ToList();

        //    return View(Book);
        //}

        public IActionResult SepeteEkle()
        {
            return Content("sepete eklenmiştir...");
        }
    }
}
