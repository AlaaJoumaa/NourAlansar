using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Models
{
    public class PhotoAlbum : Model
    {
        public string Name { get; set; }
        [ForeignKey("Language")]
        [Required]
        public int LangId { get; set; }
        public Language Language { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
