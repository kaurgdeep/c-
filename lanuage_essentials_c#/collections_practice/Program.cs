using System;
using System.Linq;
using System.Collections.Generic;


namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
        // Create an array to hold integer values 0 through 9
            var aar1 = Enumerable.Range(0,9).ToArray();
        // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            var aar2 = new string[] {"Tim", "martin","Nikki","Sara"};   
        // Create an array of length 10 that alternates between true and
        //  false values, starting with true
            var ar3 = Enumerable.Range(0,10).Select(x => x%2==0 ? true : false ).ToArray();
            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            // Initializing an empty list of flavors
            List<string> flavors = new List<string>();
            flavors.Add("vanila");
            flavors.Add("choco");
            flavors.Add("coconut");
            flavors.Add("strawberry");
            flavors.Add("tiramisu");
        // Output the length of this list after building it
            var lengthofflavors = flavors.Count;
        // Output the third flavor in the list, then remove this value.
            var thirdflavor = flavors[2];
            flavors.RemoveAt(2);
            
        // Output the new length of the list (Note it should just be one less~)
            var newlength = flavors.Count;
            Console.WriteLine(newlength);
//Create a Dictionary that will store both string keys as well as string values
            Dictionary<string,string> names = new Dictionary<string,string>();
// For each name in the array of names you made previously, add it as a new key in this dictionary with value null
// For each name key, select a random flavor from the flavor list above and store it as the value
            names.Add("gagan","vanila");
            names.Add("aman","choco");
            names.Add("geet","coconut");
            names.Add("mom","strawberry");
            names.Add("broo","tiramisu");
// Loop through the Dictionary and print out each user's name and their associated ice cream flavor.

            //The var keyword takes the place of a type in type-inference
            foreach (var entry in names)
            {
            Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
        
    }
}
