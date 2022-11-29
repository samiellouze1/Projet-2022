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
        public int Amount { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public float Tax { get; set; }
        [Required]
        public int Shipped { get; set; }
        [Required]
        public int TrackingNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public string IdCoupon { get; set; }
        [ForeignKey("IdCoupon")]
        public virtual Coupon Coupon { get; set; }

        [Required]
        public string IdCart { get; set; }
        [ForeignKey("IdCart")]
        public virtual Cart Cart { get; set; }
    }
}
