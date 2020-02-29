using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CreatedBy")]
        public ApplicationUser Creator { get; set; }
        [ForeignKey("ModifiedBy")]
        public ApplicationUser Modifier { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
