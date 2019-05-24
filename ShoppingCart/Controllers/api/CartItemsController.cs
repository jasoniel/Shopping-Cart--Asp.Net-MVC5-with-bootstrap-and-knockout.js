using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Controllers.api
{
    public class CartItemsController : ApiController
    {

        private readonly CartItemService _cartItemService = new CartItemService();
        private IMapper mapper;

        public CartItemsController()
        {
            mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Book, BookViewModel>();

                cfg.CreateMap<CartItemViewModel, CartItem>();
                cfg.CreateMap<BookViewModel, Book>();
                cfg.CreateMap<AuthorViewModel, Author>();
                cfg.CreateMap<CategoryViewModel,Category>();
            }).CreateMapper();
        }

        // POST api/<controller>
        public CartItemViewModel Post(CartItemViewModel cartItem)
        {

            var newCartItem = _cartItemService.AddToCart(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }

        // PUT api/<controller>
        public CartItemViewModel Put(CartItemViewModel cartItem)
        {

             _cartItemService.UpdateCartItem(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }


        public CartItemViewModel Delete(CartItemViewModel cartItem)
        {
            _cartItemService.DeleteCartItem(mapper.Map<CartItemViewModel, CartItem>(cartItem));

            return cartItem;
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}




