using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Product
    {
        // Product id column
        [Key]
        public int Product_Id { get; set; }

        // Product name column
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [DisplayName("Product Name")]
        public string Product_Name { get; set; }

        // product description column
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        [DisplayName("Product Description")]
        public string Product_Desc { get; set; }



        // Image 1 columns
        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Image 1: Title")]
        public string Image_Title_1 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Image_Name_1 { get; set; }
        [NotMapped]
        [DisplayName("Image 1: Upload")]
        public IFormFile Image_File_1 { get; set; }


        //Image 2 columns
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Image 2: Title")]
        public string Image_Title_2 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Image_Name_2 { get; set; }
        [NotMapped]
        [DisplayName("Image 2: Upload")]
        public IFormFile Image_File_2 { get; set; }


        // Image 3 columns
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Image 3: Title")]
        public string Image_Title_3 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Image_Name_3 { get; set; }
        [NotMapped]
        [DisplayName("Image 3: Upload")]
        public IFormFile Image_File_3 { get; set; }



        // Price column
        [Column(TypeName = "float")]
        [Required]
        [RegularExpression(@"^([0-9]{1,3}(?:,\d{3})*|[0-9]+)$")]
        [DisplayName("Price")]
        public double Price { get; set; }

        // Stock column
        [Column(TypeName = "int")]
        [Required]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        // size column
        [Column(TypeName ="nvarchar(10)")]
        [Required]
        [DisplayName("Price")]
        public string Size { get; set; }

        [NotMapped]
        [DisplayName("Category")]
        public string Category { get; set; }

        // Category id column
        [Column(TypeName ="int")]
        public int Category_Id { get; set; }


    }
}
