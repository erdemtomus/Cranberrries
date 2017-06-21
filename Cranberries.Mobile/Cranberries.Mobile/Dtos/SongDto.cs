﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cranberries.Mobile
{
    public class SongDto
    {
        public int Id { get; set; }

        public AlbumDto Album { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public string UserId { get; set; }
    }
}
