using Projet_2022.Data.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Entities
{
	public class Cart:IEntityBase
	{
		[Key]
		public string Id { get; set; }
		public virtual List<Order> Orders { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
