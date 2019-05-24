using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class CartService
    {

        private ShoppingCartContext _db = new ShoppingCartContext();


        public Cart GetBySessionId(string sessionId)
        {
            var cart = _db.Carts
                      .Include("CartItems")
                      .Where(c => c.SessionId == sessionId)
                      .SingleOrDefault();

            cart = CreateCartIfItDoesnExist(sessionId, cart);

            return cart;
                                
        }

        private Cart CreateCartIfItDoesnExist(string sessionId, Cart cart)
        {
                
            if(cart  == null)
            {

                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                _db.Carts.Add(cart);
                _db.SaveChanges();
            }

            return cart;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}