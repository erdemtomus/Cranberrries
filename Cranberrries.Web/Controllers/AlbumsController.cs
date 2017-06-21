using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.Controllers
{
    
    public class AlbumsController : Controller
    {
        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Album
        public ActionResult Index()
        {
            var albumList = _context.Albums.ToList();

            if (User.IsInRole(RoleName.Admin))
                return View("List", albumList);

            return View("ReadOnlyList",albumList);
        }


        [Authorize(Roles=RoleName.Admin)]
        public ActionResult Ekle()
        {
            Album newAlbum = new Album();

            return View("AlbumForm",newAlbum);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Duzenle(int? id)
        {
            var res = _context.Albums.SingleOrDefault(t => t.Id == id);
            if (res == null)
                return HttpNotFound();
            return View("AlbumForm",res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Album album)
        {
            if (!ModelState.IsValid)
            {
               return View("AlbumForm",album);
            }

            if (album.Id == 0)
                _context.Albums.Add(album);
            else
            {
                var albumInDb = _context.Albums.Single(t => t.Id == album.Id);
                albumInDb.Name = album.Name;
                albumInDb.ReleasedDate = album.ReleasedDate;
                albumInDb.AlbumPhotoUrl = album.AlbumPhotoUrl;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Album");

            //if (customer.Id == 0)
            //    _context.Customers.Add(customer);
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //}

            //_context.SaveChanges();

            //return RedirectToAction("Index", "Customers");

        }
    }
}