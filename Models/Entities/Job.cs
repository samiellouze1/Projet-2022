using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Job : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public double MinSalary { get; set; }
        [Required]
        public double MaxSalary { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
