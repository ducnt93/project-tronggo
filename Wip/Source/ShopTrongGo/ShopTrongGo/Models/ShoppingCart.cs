using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ListItem = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> ListItem { get; set; }

        public bool AddToCart(ShoppingCartItem item)
        {
            bool alreadyExists = ListItem.Any(x => x.ProductId == item.ProductId);
            if (alreadyExists)
            {
                ShoppingCartItem existsItem = ListItem.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (existsItem != null)
                {
                    existsItem.Quantity = existsItem.Quantity + 1;
                    existsItem.Total = existsItem.Quantity * existsItem.Price;
                }
            }
            else
            {
                ListItem.Add(item);
            }
            return true;
        }

        public bool RemoveFromCart(string lngProductSellId)
        {
            ShoppingCartItem existsItem = ListItem.SingleOrDefault(x => x.ProductId == lngProductSellId);
            if (existsItem != null)
            {
                ListItem.Remove(existsItem);
            }
            return true;
        }

        public bool UpdateQuantity(string lngProductSellId, int intQuantity)
        {
            ShoppingCartItem existsItem = ListItem.SingleOrDefault(x => x.ProductId == lngProductSellId);
            if (existsItem != null)
            {
                existsItem.Quantity = intQuantity;
                existsItem.Total = existsItem.Quantity * existsItem.Price;
            }
            return true;
        }

        public decimal GetTotal()
        {
            return ListItem.Sum(x => x.Total);
        }

        public bool EmptyCart()
        {
            ListItem.Clear();
            return true;
        }
    }
    public class ShoppingCartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}