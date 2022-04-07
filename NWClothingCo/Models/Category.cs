using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Category
    {
        // Category id column
        [Key]
        public int Category_Id { get; set; }

        // Category name column
        [Column(TypeName ="nvarchar(50)")]
        public string Category_Name {get; set;}

        // Category description column
        [Column(TypeName = "nvarchar(MAX)")]
        public string Category_Desc { get; set; }

        // Category image columns
        [Column(TypeName = "nvarchar(50)")]
        public string Category_Image_Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Category_Image_Name { get; set; }
    }
}
