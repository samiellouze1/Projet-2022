
using Projet_2022.Data.Repository;
using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Assoc
{
    public class OrderCart
    {

        [Required]
        public string IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        [Required]
        public string IdCart { get; set; }
        [ForeignKey("IdCart")]
        public virtual Cart Cart { get; set; }
    }
}
