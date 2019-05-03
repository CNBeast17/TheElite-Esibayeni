using System;
using System.Collections.Generic;
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
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? BatchID { get; set; }
        public virtual Batch Batch { get; set; }
        public decimal Weight { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public decimal CostPrice { get; set; }


    }
}