﻿using GeekShopping.Product.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.API.Model
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Column("price")]
        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;

        [Column("image_url")]
        [StringLength(300)]
        public string ImageURL { get; set; } = string.Empty;
    }
}
