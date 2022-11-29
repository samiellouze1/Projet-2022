using Projet_2022.Data.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Models.Assoc;

namespace Projet_2022.Models.Entities
{
    public class GalleryProductOption:IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string IdProductOption { get; set; } 
        [ForeignKey("IdProductOption")]
        public virtual ProductOption ProductOption { get; set; }
    }
}
