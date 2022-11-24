using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Employee:IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Phone { get; set; }
        public int IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public virtual Country Country { get; set; }
        public int IdJob { get; set; }
        [ForeignKey("IdJob")]
        public virtual Job Job { get; set; }

    }
}
