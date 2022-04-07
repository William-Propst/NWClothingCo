using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Order_Details
    {
        [Key]
        public int Order_Details_Id { get; set; }
        
        [Column(TypeName="int")]
        public int Product_Id { get; set; }

        [Column(TypeName ="int")]
        public int Product_Qty { get; set; }

        [Column(TypeName ="float")]
        public float Product_Price { get; set; }

        [Column(TypeName = "float")]
        public float Item_total { get; set; }

        [Column(TypeName ="int")]
        public int Order_Id { get; set; }
    }
}
