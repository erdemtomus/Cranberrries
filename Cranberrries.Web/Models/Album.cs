using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cranberrries.Web.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Albüm Adı")]
        public string Name { get; set; }
        
        public DateTime? ReleasedDate { get; set; }
        public string AlbumPhotoUrl { get; set; }


    }
}