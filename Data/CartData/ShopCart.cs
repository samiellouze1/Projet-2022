using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.Entities;

namespace Projet_2022.Data.CartData
{
	public class ShopCart
	{
		public AppDbContext _context { get; set; }
		public string IdCart { get; set; }
		public List<Order> Orders {get; set;}
		public ShopCart(AppDbContext context)
		{
			_context = context;
		}
		public List<Order> GetOrders()
		{
			return Orders ?? (Orders = _context.Orders.Where(n => n.IdCart == IdCart).Include(n => n.Product).ToList());
		}
		public int GetTotal()
		{
			var total = GetOrders().Select(n=>n.Product.MaxPrice*n.Amount).Sum();
			return total;

        }
		public void AddProductToCart(Product product)
		{
			var order = _context.Orders.FirstOrDefault(n => n.Product.Id == product.Id && n.IdCart == IdCart);
			if (order==null)
			{
				order = new Order()
				{
					IdCart = IdCart,
					Product = product,
					Amount = 1,
				};
				_context.Orders.Add(order);
			}else
			{
				order.Amount++;
			}
			_context.SaveChanges();
		}
	}
}
