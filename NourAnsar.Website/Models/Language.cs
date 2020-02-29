using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Models
{
    public class Language : Model
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
