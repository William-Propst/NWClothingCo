using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        [Column(TypeName ="nvarchar(450)")]
        public string User_Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage = "Address line 1 is required")]
        public string Address_Line1 { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Address_Line2 { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string City { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Column(TypeName ="nvarchar(25)")]
        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string PostalCode { get; set; }
    }
}
