using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cranberries.Mobile
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string AlbumPhotoUrl { get; set; }

    }
}
