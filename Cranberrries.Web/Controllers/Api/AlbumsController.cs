using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Cranberrries.Web.Dtos;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.Controllers.Api
{

    public class AlbumsController : ApiController
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


        // GET api/albums
        public IEnumerable<AlbumDto> GetAlbums()
        {
            var res = _context.Albums.ToList().Select(Mapper.Map<Album,AlbumDto>);
            return res;
        }

        //GET api/albums/1
        public AlbumDto GetAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(t => t.Id==id);

            if(album==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Album, AlbumDto>(album);
        }


        //POST api/albums
        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDto albumDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var newAlbum = Mapper.Map<AlbumDto, Album>(albumDto);

            _context.Albums.Add(newAlbum);
            _context.SaveChanges();

            albumDto.Id = newAlbum.Id;

            return Created(new Uri(Request.RequestUri + "/" + albumDto.Id), albumDto);
            //return album;
        }

        [HttpPut]
        public void UpdateAlbum(int id, AlbumDto albumDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var albumInDb = _context.Albums.SingleOrDefault(t => t.Id == id);
            if(albumInDb==null)
                throw  new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(albumDto, albumInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteAlbum(int id)
        {
            var albumInDb = _context.Albums.SingleOrDefault(t => t.Id == id);
            if (albumInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Albums.Remove(albumInDb);
            _context.SaveChanges();
        }

    }
}
