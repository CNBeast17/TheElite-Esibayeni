using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esibayeni.Models
{
    public class Batch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Batch number is required to process")]
        [DisplayName("Batch No")]
        public int BatchNo { get; set; }
        [DisplayName("Supplier Name")]
        public int? SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
        [DisplayName("Category Type")]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Quantity number is required to process")]
        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [DisplayName("Batch Cost")]
        public decimal BatchCost { get; set; }

        public Decimal Price()
        {
            return BatchCost / Quantity;

        }

        public DateTime DateNow()
        {
            return DateTime.Now;
        }


    }
}