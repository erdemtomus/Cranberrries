using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.Dtos
{
    public class SongDto
    {
        public int Id { get; set; }

        public AlbumDto Album { get; set; }
        [Display(Name = "Album")]
        [Required]
        public int AlbumId { get; set; }
        [Display(Name = "Song Name")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        [AllowHtml]
        [Required]
        public string Lyrics { get; set; }
        [Display(Name = "Written By")]
        [StringLength(128)]
        public string UserId { get; set; }
    }
}