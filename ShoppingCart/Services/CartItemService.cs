using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class CartItemService : IDisposable
    {

        private ShoppingCartContext _db = new ShoppingCartContext();

        public CartItem GetByCartIdAndBookId(int cartId, int bookId)
        {

            return _db.CartItems.SingleOrDefault(ci => ci.CartId == cartId && ci.BookId == bookId);
        }

        public CartItem AddToCart(CartItem cartItem)
        {
            var existingCartItem = GetByCartIdAndBookId(cartItem.CartId, cartItem.BookId);

            if(existingCartItem == null)
            {
                _db.Entry(cartItem).State = System.Data.Entity.EntityState.Added;
                existingCartItem = cartItem;
            }
            else
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }
            _db.SaveChanges();

            return existingCartItem;
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _db.Entry(cartItem).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }


        public void DeleteCartItem(CartItem cartItem)
        {
            _db.Entry(cartItem).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}