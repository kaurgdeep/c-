using System;
using System.Collections.Generic;

namespace basic_13
{
    class Program
    {
    // Print all the numbers from 1 to 255.
        public static void print1to255()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }
    // Print all the odd numbers from 1 to 255.
        public static void printodd()
        {
            for (int i = 1; i < 255; i = i + 2)
            {
                Console.WriteLine(i);
            }
        }

    // Print the numbers from 0 to 255, but this time, also print the
    //  sum of the numbers that have been printed so far. 
        public static void printnumsum()
        {
            int sum = 0;
            for (int i = 0; i < 255; i++)
            {
                sum += i;
                Console.WriteLine("New Number: {0} sum: {1}", i, sum);

            }
        } 

    //Given an array X, say [1,3,5,7,9,13], write a function that would iterate through each member of the array and print each value on the screen. Being able to loop through each 
    // member of the array is extremely important.
        public static void iterate(int[] arr)
        {
            foreach (int val in arr)
            {
                Console.WriteLine(val);
            }

        }
// Find Max

// Write a function that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]),
//  or even a mix of positive numbers, negative numbers and zero
        public static int findmax(int[] arr)
        {
            int max = arr[0];
            foreach (int val in arr)
            {
                if (val>max)
                {
                    max = val;

                }
            }
            return max;
        }

// Get Average
// Write a function that takes an array and prints the AVERAGE of the values in the array. For example, for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instr
//  other complicated cases. You can use a count function with this assignment.
        public static int avg(int[] arr)
        {
            int sum = 0;
            foreach(int val in arr)
            {
                sum += val;
            }
            return sum/arr.Length;
        }


        public static Array oddArray()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i < 256; i = i+2)
            {
                nums.Add(i);
            }
            int[] new_arr = nums.ToArray();
            return new_arr;
        }




        // public static int greaterThanY(int [] arr, int y)
        // {
        //     int count = 0;
        //     foreach (int num in arr)
        //     {
        //         if (num > y)
        //         {
        //             count++;
        //         }
        //     }
        //     return count;
        // }
        
        // public static Array squareTheValues(int[] arr)
        // {
        //     for (int i = 0; i < arr.Length; i++)
        //     {
        //         arr[i] *= arr[i];
        //     }
        //     return arr;
        // }

        // public static Array eliminateNegatives(int[] arr)
        // {
        //     for (int i = 0; i < arr.Length; i++)
        //     {
        //         if (arr[i] < 0)
        //         {
        //             arr[i] = 0;
        //         }
        //     }
        //     return arr;
        // }

        // public static void minMaxAvg(int[] arr)
        // {
        //     int sum = 0;
        //     int min = arr[0];
        //     int max = arr[0];
        //     foreach (int val in arr)
        //     {
        //         sum += val;
        //         if (val < min)
        //         {
        //             min = val;
        //         }
        //         else if (val > max)
        //         {
        //             max = val;
        //         }
        //     }
        //     Console.WriteLine("Min: {0}. Max: {1}. Avg: {2}.", min, max, sum/arr.Length);
        // }

        // public static Array shiftValLeft(int[] arr)
        // {
        //     for (var i = 1; i < arr.Length; i++)
        //     {
        //         arr[i-1] = arr[i];
        //     }
        //     arr[arr.Length-1] = 0;
        //     return arr;
        // }
        // public static Array numberToString(int[] arr)
        // {
        //     List<object> holder = new List<object>();
        //     foreach (int val in arr)
        //     {
        //         if (val < 0)
        //         {
        //             holder.Add("Dojo");
        //         }
        //         else
        //         {
        //             holder.Add(val);
        //         }
        //     }
        //     object[] ans = holder.ToArray();
        //     return ans;
        // }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            oddArray();
            
            
            

           

        }
    }
}
