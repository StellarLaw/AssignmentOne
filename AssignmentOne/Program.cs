using System.Reflection.Metadata.Ecma335;

namespace AssignmentOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory(); // create a new inventory
            Shop shop = new Shop(inventory); // create a new shop with the inventory

            while (true)
            {
                //main menu
                Console.WriteLine("Welcome to the Inventory Manager!");
                Console.WriteLine("1. Inventory Management");
                Console.WriteLine("2. Shop");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                
                if (option == "1")
                {
                    InventoryManagement(inventory);
                }
                else if (option == "2")
                {
                    Shopping(shop,inventory);
                }
                else if (option == "3")
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        //inventory management options
        static void InventoryManagement(Inventory inventory)
        {
            while (true)
            {
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View Items");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    int id = GetUniqueIntInput(inventory, "Enter Id: ");
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine();
                    double price = GetValidDoubleInput("Enter Price: ");
                    int quantity = GetValidIntInput("Enter Quantity: ");

                    inventory.AddItem(new Item(name, description, price, id, quantity));
                }
                else if (option == "2")
                {
                    inventory.DisplayItems();
                }
                else if (option == "3")
                {
                    int id = GetValidIntInput("Enter ID of item to update: ");
                    Console.Write("Enter new Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter new Description: ");
                    string description = Console.ReadLine();
                    double price = GetValidDoubleInput("Enter new Price: ");
                    int quantity = GetValidIntInput("Enter new Quantity: ");

                    inventory.UpdateItem(id, name, description, price, quantity);
                }
                else if (option == "4")
                {
                    int id = GetValidIntInput("Enter ID of item to delete: ");
                    inventory.DeleteItem(id);
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        //shopping option for users

        static void Shopping(Shop shop, Inventory inventory)
        {
            while (true)
            {
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. Display Cart Items");
                Console.WriteLine("3. Remove from Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    inventory.DisplayItems();

                    int id = GetValidIntInput("Enter ID of item to add to cart: ");
                    int quantity = GetValidIntInput("Enter quantity: ");
                    shop.AddToCart(id, quantity);
                }
                else if (option == "2")
                {


                    shop.DisplayCart();
                }
                else if (option == "3")
                {
                   

                    int id = GetValidIntInput("Enter ID of item to remove from cart: ");
                    shop.RemoveFromCart(id);
                }
                else if (option == "4")
                {
                    shop.Checkout();
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        //get valid int input from user
        static int GetValidIntInput(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))// parse the input as a int
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        //get valid double input from the user
        static double GetValidDoubleInput(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value)) // parse the input as a double
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid double number.");
            }
        }

        // Method to get a unique integer input from the user
        static int GetUniqueIntInput(Inventory inventory, string prompt)
        {
            int id;
            while (true)
            {
                id = GetValidIntInput(prompt);
                if (inventory.GetItemById(id) == null)
                {
                    return id;
                }
                Console.Write("That ID is taken, try again.");
            }
        }
    }
}




