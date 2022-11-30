using Projet_2022.Data.Repository;
using Projet_2022.Models.Assoc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Entities
{
    public class Cart:IEntityBase
	{
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public virtual List<OrderCart> OrdersCart { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
