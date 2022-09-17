using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WorldTelecomFinal.Models
{
    public class Tag
    {
        
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
        public IEnumerable<ProductTag> ProductsTags { get; set; }

    }
}
