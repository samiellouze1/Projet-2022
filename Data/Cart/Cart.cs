using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.Entities;

namespace Projet_2022.Data.Cart
{
    public class Cart
    {
        public string IdCart { get; set; }
        public AppDbContext _context { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Cart(AppDbContext context)
        {
            _context = context;
        }
        public void AddItemToCart(Product Product)
        {
            var cartitem = _context.CartItems.FirstOrDefault(n => n.Product.Id == Product.Id && n.IdCart == IdCart);
            if (cartitem==null)
            {
                cartitem = new CartItem()
                {
                    IdCart = IdCart,
                    Product = Product,
                    Amount = 1
                };
                _context.CartItems.Add(cartitem);
                _context.SaveChanges();
            }
            else
            {
                cartitem.Amount ++;
            }
        }
        public void RemoveItemFromCart(Product Product)
        {
            var cartitem = _context.CartItems.FirstOrDefault(n => n.Product.Id == Product.Id && n.IdCart == IdCart);
            if (cartitem != null)
            {
                if (cartitem.Amount > 1)
                {
                    cartitem.Amount--;
                }
                else
                {
                    _context.CartItems.Remove(cartitem);
                }
            }
            else
            {
                cartitem.Amount++;
            }
        }
        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _context.CartItems.Where(n => n.IdCart == IdCart).Include(n => n.Product).ToList());
        }
        public float GetShoppingCartTotal()
        {
            var total = _context.CartItems.Where(n => n.IdCart == IdCart).Select(n => n.Product.MaxPrice * n.Amount).Sum();
            return total;
        }
        public async Task CLearCartAsync()
        {
            var items = await _context.CartItems.Where(n => n.IdCart == IdCart).ToListAsync();
            _context.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
