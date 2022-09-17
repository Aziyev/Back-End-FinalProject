using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldTelecomFinal.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
