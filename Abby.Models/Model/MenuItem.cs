﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.Models.Model
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Image { get;set;}
        
        [Range(1, 1000, ErrorMessage = "Price should be between $1 and $1000")]
        public double Price { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set;}
        
        [ForeignKey("FoodTypeId")]
        public FoodType FoodType { get; set; }
        
        [Display(Name="Category")]
        public int CategoryId { get; set;}

        //ForeignKey is not needed if the PropertyName matches PropertyNameId
        public Category Category { get; set; }

    }
}
