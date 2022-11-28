using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Order : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Ship_address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip_code { get; set; }
        [Required]
        public string Tax { get; set; }
        [Required]
        public string Shipped { get; set; }
        [Required]
        public int Tracking_number { get; set; }
        [Required]
        public DateTime Date_of_order { get; set; }
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public virtual List<Coupon> Coupons { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User {get; set;}
    }
}
