using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Cranberrries.Web.Dtos;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.Controllers.Api
{
    public class SongsController : ApiController
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


        // GET api/albums
        //public IEnumerable<SongDto> GetAlbums()
        public IHttpActionResult GetAlbums()
        {
            var res = _context.Songs.Include(t => t.Album).ToList().Select(Mapper.Map<Song, SongDto>);
            return Ok(res);
        }

    }
}
