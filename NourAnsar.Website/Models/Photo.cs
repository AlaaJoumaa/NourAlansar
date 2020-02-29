using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Models
{
    public class Photo : Model
    {
        public string Name { get; set; }
        public string Img { get; set; }
        [ForeignKey("PhotoAlbum")]
        [Required]
        public int PhotoAlbumId { get; set; }
        public PhotoAlbum PhotoAlbum { get; set; }
    }
}