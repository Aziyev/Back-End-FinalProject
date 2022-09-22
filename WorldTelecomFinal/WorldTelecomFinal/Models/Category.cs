using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldTelecomFinal.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Category> Children { get; set; }

        public IEnumerable<Product> Products { get; set; }


    }
}
