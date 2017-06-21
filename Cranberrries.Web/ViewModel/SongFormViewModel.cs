using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.ViewModel
{
    public class SongFormViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<ApplicationUser> SongWriters { get; set; }
        public Song Song { get; set; }
    }

    public class SongFormDetailViewModel
    {
        public Song Song { get; set; }
        public Album Album { get; set; }
        public ApplicationUser User { get; set; }
    }
}