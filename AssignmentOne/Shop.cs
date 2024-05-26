using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    public class Shop
    {
        private Inventory inventory;        //ref to inventory
        private List<Item> cart = new List<Item>(); //list to store items in cart

        public Shop(Inventory inventory)
        {
            this.inventory = inventory;     //initializes shop with given inventory
        }
        //method to add item tocart
        public void AddToCart(int id, int quantity)
        {
            var item = inventory.GetItemById(id);   //find item by idin inventory

            if (item != null && item.Quantity >= quantity) 
            {
                cart.Add(new Item(item.Name, item.Description, item.Price, item.Id, quantity));
                item.Quantity -= quantity;  //decrease quantity in inventory
               
                Console.WriteLine("Item added to cart!");
            }
            else
            {
                Console.WriteLine("Item not available or insufficient quantity");
            }
        }
        public void DisplayCart()
        {
            Console.WriteLine("Cart Items: ");
            foreach (var item in cart)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void RemoveFromCart(int id) 
        {
            var cartItem = cart.Find(i => i.Id == id);      //finds item by id 
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                var item = inventory.GetItemById(id);
                if (item == null)
                {
                    inventory.AddItem(item);
                }
                item.Quantity += cartItem.Quantity; //return quantity to inventory

                Console.WriteLine("Item removed from cart!");
            }
            else
            {
                Console.WriteLine("Item not found in cart");
            }
        }


        public void Checkout()
        {
            double subtotal = 0;
            Console.WriteLine("Receipt:");

            foreach (var item in cart)
            {
                if (item != null) // check if item is not null
                {
                    Console.WriteLine(item);
                    subtotal += item.Price * item.Quantity; // perform calc
                }
            }

            double tax = subtotal * 0.07;
            double total = subtotal + tax;
            Console.WriteLine($"Subtotal: {subtotal:C}, Tax: {tax:C}, Total: {total:C}");

            //cart.Clear(); // clear the cart after checkout
        }
    }
}
