using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldTelecomFinal.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public double DiscoutnPrice { get; set; }
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        [StringLength(maximumLength: 255)]
        public string MainImage { get; set; }
        public int BrandId { get; set; }
        [Range(0, 9999)]

        public bool BestSeller { get; set; }

        public bool IsNewArrivel { get; set; }


        public Nullable<int> CategoryId { get; set; }
        public Category Category { get; set; }


        //Elave xarakteristikalar
        public string Color { get; set; }
        public int Code { get; set; }
        public string Screen { get; set; }
        public string RAM { get; set; }
        public string CPU { get; set; }
        public string Weight { get; set; }
        public string Momery { get; set; }

        public Brand Brand { get; set; }
        public IEnumerable<ProductTag> ProductsTags { get; set; }
        public IEnumerable<ProductImage> ProductsImages { get; set; }
    }
}
