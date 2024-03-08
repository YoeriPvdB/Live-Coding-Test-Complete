using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN___Live_Coding_Test_Complete
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            
        }
    }

    class Inventory
    {
        Dictionary<string, Item> itemList = new Dictionary<string, Item>();

        

        int highestCost { get; set; }
       
        public Inventory()
        {
            GetCommands();
        }

        

        void GetCommands()
        {
            Console.WriteLine("What would you like to do?");

            switch(UserInput())
            {
                case "Add":
                    Add();
                    break;

                case "Remove":
                    Remove();
                    break;

                case "Get":
                    Get();
                    break;

                case "GetByType":
                    GetByType();
                    break;

                case "GetMostExpensive":
                    GetByMostExpensive();
                    break;
            }
        }

        void Add()
        {
            
            Console.WriteLine("Item Name: ");

            string name = UserInput();
            if (itemList.ContainsKey(name))
            {
                Console.WriteLine("Item already exists!");
                GetCommands();
            }

            Item newItem = new Item();
            newItem.name = name;

            Console.WriteLine("Description : ");
            newItem.description = UserInput();

            Console.WriteLine("Cost : ");
            newItem.cost = int.Parse(UserInput());

            if(itemList.Count < 100)
            {
                itemList.Add(newItem.name, newItem);
            } else
            {
                Console.WriteLine("Inventory is full");
            }

            CheckCost(newItem.cost);

            Console.WriteLine("Item Type  (Weapon, Consumbable, Trophy)  :");
            newItem.type = SetType(UserInput());

            GetCommands();
        }

        void Remove()
        {
            Console.WriteLine("What Item do you want to remove? ");

            itemList.Remove(UserInput());

            GetCommands();
        }

        void Get()
        {
            Console.WriteLine("What Item are you looking for?");
            string query = UserInput();
            List(query);

            
        }

        void List(string query)
        {
            Console.WriteLine("Item name : " + itemList[query].name);
            Console.WriteLine("Item Description : " + itemList[query].description);
            Console.WriteLine("Item Cost : " + itemList[query].cost);
            Console.WriteLine("Item Description : " + itemList[query].type);

            GetCommands();
        }

        void GetByType()
        {
            Console.WriteLine("What type are you searching for?");

            string selectedType = UserInput();
            
            foreach (Item item in itemList.Values)
            {
                if (item.type == selectedType)
                {
                    List(item.name);
                }
            }
        }

        void GetByMostExpensive()
        {
            foreach(Item item in itemList.Values)
            {
                if(item.cost == highestCost)
                {
                    List(item.name);
                }
            }
        }

        string UserInput()
        {
            return Console.ReadLine();
        }

        void CheckCost(int newItemCost)
        {
            if(newItemCost > highestCost)
            {
                highestCost = newItemCost;
            }

            return;
        }

       string SetType(string input)
        {
            string[] types = { "Weapon", "Consumbale", "Trophy" };

            if(types.Contains<string>(input))
            {
                return input;
            } else
            {
                Console.WriteLine("Not valid Item type.");
                return SetType(UserInput());
                
            }
        }
    }

    class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public int cost { get; set; }

        public string type { get; set; }

        


    }
}
