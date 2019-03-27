using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkShopCore.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace DrinkShopCore.Entities
{
   
    public class Product:IEntity
    {
      
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Product Name can not be empty")]
        [RegularExpression("^[-_, @.A-Za-z0-9]*$",ErrorMessage = "Invalid characters ")]
        public string ProductName { get; set; }
        public string Image { get; set; }
        [Range(0,5000,ErrorMessage = "Invalid Unit  Unit(Range 0,5000)")]
        public int UnitPrice { get; set; }
        [Range(0,1000,ErrorMessage = "Invalid Stock Unit(Range 0,1000)")]
        public int UnitInStock { get; set; }
        
        public int CategoryId { get; set; }
        
        public int SubCategoryId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Enter Product Image")]
        public IFormFile ImageUpload { get; set; }
    }
}
