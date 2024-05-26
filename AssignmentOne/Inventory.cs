using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    //handles item crud
    public class Inventory
    {
        //list to store itemsin inventory
        private List<Item> items = new List<Item>();

        //method to find item by id
        public Item GetItemById(int id)
        {
            return items.Find(i => i.Id == id);     //finds item by id
        }
        //method to add item
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item Added!");
        }
        //method to display item
        public void DisplayItems()
        {
            Console.WriteLine("Inventory Items: ");
            foreach (var item in items)             //iteraters through list and prints items
            {
                Console.WriteLine(item.ToString());
            }
            
         }
        
        //method to update item
        public void UpdateItem(int id, string name, string description, double price, int quantity)
        {
            Item item = items.Find(i => i.Id == id);    //finds item by id
            if (item != null)
            {

                item.Name = name;
                item.Description = description;
                item.Price = price;
                item.Quantity = quantity;
                Console.WriteLine("item updated!");

            } 
            else
            {
                Console.WriteLine("Item not found!");
            }
        }

        //method to remove item
        public void DeleteItem(int id)
        {
            Item item = items.Find(i => i.Id == id); //finds item by id
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine("item deleted!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }
        }


    }
}
