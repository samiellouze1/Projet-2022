using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Coupon :IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public DateTime Startdate { get; set; }
        [Required]
        public DateTime Enddate { get; set; }
        public string IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order {get;set;}
    }
}
