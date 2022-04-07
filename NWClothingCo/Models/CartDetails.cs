using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class CartDetails
    {
        [Key]
        public int Cart_Details_Id { get; set; }

        [Column(TypeName = "int")]
        public int Cart_Id { get; set; }

        [Column(TypeName = "int")]
        public int Product_Id { get; set; }

        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date_Added { get; set; }
    }
}
