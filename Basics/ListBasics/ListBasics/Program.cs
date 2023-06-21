// list = data structure that holds a sequence of elements of the same type and can be accessed by index.
//      Similar to Array but more flexible. It dynamically increase/decrease in size.
//      using System.Collections.Generic;
//here you may find some helpful basics, hope you like it :)

using System;
using System.Collections.Generic;

namespace ListBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> products = new List<String>();

            // Add elements to the list
            products.Add("Phone");
            products.Add("Computer");
            products.Add("Tablet");
            products.Add("Smart Watch");
            //Display the list
            foreach (String product in products)
            {
                Console.WriteLine(product);
            }
            //Display an element by index
            Console.WriteLine("____________________________________");
            Console.WriteLine($"The element at index 1 is : {products[1]}");
            //Display the number of elements in the list
            Console.WriteLine("____________________________________");
            Console.WriteLine($"The number of elements in the list is : {products.Count}");
            //To remove an element from the list
            products.Remove("Smart Watch");
            //Now display the new list
            Console.WriteLine("____________________________________");
            Console.WriteLine("This the new list after removing the item Smart Watch");
            foreach (String product in products)
            {
                Console.WriteLine(product);
            }
            //insert an element at a specific index
            products.Insert(2, "Smart Watch");
            //Now display the new list
            Console.WriteLine("____________________________________");
            Console.WriteLine("This the new list after inserting the item Smart Watch at index 2");
            foreach (String product in products)
            {
                Console.WriteLine(product);
            }
            //display the index of an element
            Console.WriteLine("____________________________________");
            Console.WriteLine($"The index of the element Smart Watch is : {products.IndexOf("Smart Watch")}");
            //check if the list contains a specific element
            Console.WriteLine("____________________________________");
            Console.WriteLine($"The list contains the element Phone : {products.Contains("Phone")}");
            //sort the list
            products.Sort();
            //Now display the new list
            Console.WriteLine("____________________________________");
            Console.WriteLine("This the new list after sorting the list");
            foreach (String product in products)
            {
                Console.WriteLine(product);
            }
            //sort the list in reverse
            products.Reverse();
            //Now display the new list
            Console.WriteLine("____________________________________");
            Console.WriteLine("This the new list after sorting the list in reverse");
            foreach (String product in products)
            {
                Console.WriteLine(product);
            }
            //clear the list
            //products.Clear();

            //convert the list to an array
            String[] array = products.ToArray();
            //display the array
            Console.WriteLine("____________________________________");
            Console.WriteLine("This is the array");
            foreach (String product in array)
            {
                Console.WriteLine(product);
            }
            


        }
    }
}

