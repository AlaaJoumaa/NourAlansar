using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Models
{
    public class Project : Model
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DefaultValue(0)]
        public decimal MaxAmount { get; set; }
        [DefaultValue(0)]
        public decimal AmountBalance { get; set; }
        public string Img { get; set; }
        [ForeignKey("Language")]
        [Required]
        public int LangId { get; set; }
        public Language Language { get; set; }
    }
}
