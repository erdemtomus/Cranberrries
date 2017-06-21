using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Cranberrries.Web.Models;
using Cranberrries.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Cranberrries.Web.Controllers
{
    public class SongsController : Controller
    {
        private ApplicationDbContext _context;

        public SongsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Song
        public ActionResult Index()
        {
            var songList = _context.Songs.Include(t=>t.Album).ToList();
            
            //var user = UserManagerExtensions.FindById(new UserManager<IUser>(new IUser), )
            
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());

            //string userName = Membership.GetUser(User.Identity.GetUserId()).UserName;


            if (User.IsInRole(RoleName.Admin))
                return View("List", songList);

            return View("ReadOnlyList", songList);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Ekle()
        {
            var viewModel = new SongFormViewModel
            {
                Albums = _context.Albums.ToList(),
                SongWriters = _context.Users.ToList(),
                Song =  new Song()
            };

            return View("SongForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            var res = _context.Songs.SingleOrDefault(t => t.Id == id);
            if (res == null)
                return HttpNotFound();

            var viewModel = new SongFormViewModel
            {
                Albums = _context.Albums.ToList(),
                Song = res,
                SongWriters = _context.Users.ToList()
            };

            return View("SongForm", viewModel);
        }


        [HttpPost]
        //[ValidateInput(false)] // [AllowHtml] yaptık gittik o alana
        [ValidateAntiForgeryToken]
        public ActionResult Save(SongFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SongForm", viewModel);
            }

            if (viewModel.Song.Id == 0)
                _context.Songs.Add(viewModel.Song);
            else
            {
                var songInDb = _context.Songs.Single(t => t.Id == viewModel.Song.Id);
                _context.Entry(songInDb).CurrentValues.SetValues(viewModel.Song);
                
                //songInDb = viewModel.Song;
                //DbEntityEntry entry = _context.Entry(songInDb);
                //entry.State = EntityState.Modified;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Song");

        }


        public ActionResult Detail(int id)
        {
            var res = _context.Songs.Include(t=>t.Album).Single(t => t.Id == id);
            if (res == null)
                return HttpNotFound();

            ApplicationUser user = null;
            try
            {
                user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(res.UserId);
            }
            catch (Exception ex)
            {
                user = new ApplicationUser
                {
                    UserName = "error:" + ex.Message + "-inner message : " // + ex.InnerException.Message
                };
            }

            

            //var membershipUser = Membership.GetUser(res.UserId);
            
            SongFormDetailViewModel usModel = new SongFormDetailViewModel
            {
                Song = res,
                Album = res.Album,
                User = user
            };

            return View("Detail",usModel);
        }
    }
}