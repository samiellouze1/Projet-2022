using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class User :IdentityUser,IEntityBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get;set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public bool EmailVerification { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Registration_Date { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
