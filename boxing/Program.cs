using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
    // Create an empty List of type object
            List<object> mylist = new List<object>();
    // Add the following values to the list: 7, 28, -1, true, "chair"
            mylist.Add(7);
            mylist.Add(28);
            mylist.Add(-1);
            mylist.Add(true);
            mylist.Add("chair");
    // Loop through the list and print all values (Hint: Type Inference might help here!)
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }
    // Add all values that are Int type together and output the sum
            int sum = 0;
            foreach (var item in mylist)
            {
                if (item is int){
                    sum += Convert.ToInt32(item);
                }
            }
            Console.WriteLine("The sum of the integers is {0}",sum);

        }
    }
}
