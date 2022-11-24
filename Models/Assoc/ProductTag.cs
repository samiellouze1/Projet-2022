using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Assoc
{
    public class ProductTag
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
