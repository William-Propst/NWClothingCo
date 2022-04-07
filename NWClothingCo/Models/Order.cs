using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Order
    {
        [Key]
        public int Oder_Id { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string Order_No { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime Order_Date { get; set; }

        [Column(TypeName ="float")]
        public float Order_Total { get; set; }

        [Column(TypeName ="int")]
        public int Customer_Id { get; set; }

        [Column(TypeName ="bit")]
        public bool Is_Delivered { get; set; }
    }
}
