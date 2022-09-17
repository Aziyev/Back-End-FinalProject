﻿using System.Collections;
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
        public int IsAviable { get; set; }
        public int BrandId { get; set; }
        [Range(0, 9999)]


        //Elave xarakteristikalar
        public int Code { get; set; }
        public int Screen { get; set; }
        public int RAM { get; set; }
        public int CPU { get; set; }
        public int Weight { get; set; }
        public int Momery { get; set; }

        public Brand Brand { get; set; }
        public IEnumerable<ProductTag> ProductsTags { get; set; }
        public IEnumerable<ProductImage> ProductsImages { get; set; }
    }
}