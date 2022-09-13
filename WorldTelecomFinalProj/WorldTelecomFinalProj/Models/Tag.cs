using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTelecomFinalProj.Models

{
    public class Tag
    {

       
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        
        public string Name { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }



    }
}
