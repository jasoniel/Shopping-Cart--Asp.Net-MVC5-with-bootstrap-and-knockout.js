using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Cart
    {

        public int Id { get; set; }

        [StringLength(255)]
        [Index(IsUnique =true)]
        public string SessionId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}