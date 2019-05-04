using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Esibayeni.Models
{
    public class LivesStock
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("Type")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Batch No")]
        public int? BatchID { get; set; }
        public virtual Batch Batch { get; set; }
        public decimal Weight { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        [DisplayName("Cost Price")]
        public decimal CostPrice { get; set; }


    }
}