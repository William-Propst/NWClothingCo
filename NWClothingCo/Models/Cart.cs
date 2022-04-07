using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Cart
    {
        [Key]
        public int Cart_Id { get; set; }

        [Column(TypeName =("nvarchar(50)"))]
        public string Cart_No { get; set; }

        [Column(TypeName = "int")]
        public int Customer_Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CartEpirationDate { get; set; }
    }
}
