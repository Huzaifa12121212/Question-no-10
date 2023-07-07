using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question20
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st string:");
            string input1 = Console.ReadLine();
            string[] subsequences1 = FindSubsequences(input1);

            Console.WriteLine("Enter 2nd string:");
            string input2 = Console.ReadLine();
            string[] subsequences2 = FindSubsequences(input2);


            string[] commonSubsequences = FindCommonSubsequences(subsequences1, subsequences2);

            Console.WriteLine(new string('_', 100));

            Console.WriteLine("The longest common sequence is: " + commonSubsequences[commonSubsequences.Length - 1]);


            Console.ReadLine();


            
        }

        static string[] FindSubsequences(string input)  // This function itterate in both the Arrays and then compare all strings and append the common string in new array
        {
            int numSubsequences = (int)Math.Pow(2, input.Length); // Calculate the number of possible subsequences
            string[] subsequences = new string[numSubsequences];

            subsequences[0] = ""; // Add an empty subsequence

            int count = 1; // Keep track of the current count of subsequences

            for (int i = 0; i < input.Length; i++)
            {
                int currentCount = count; // Store the current count of subsequences
                for (int j = 0; j < currentCount; j++)
                {
                    string newSubsequence = subsequences[j] + input[i]; // Append the current character to each existing subsequence
                    subsequences[count++] = newSubsequence; // Add the new subsequence at the current count index and increment count
                }
            }

            return subsequences;
        }
        static string[] FindCommonSubsequences(string[] subsequences1, string[] subsequences2)
        {
            string[] commonSubsequences = new string[subsequences1.Length]; // Create an array to store the common subsequences
            int count = 0; // Keep track of the current count of common subsequences

            for (int i = 0; i < subsequences1.Length; i++)
            {
                for (int j = 0; j < subsequences2.Length; j++)
                {
                    if (subsequences1[i] == subsequences2[j]) // Compare each string in subsequences1 with each string in subsequences2
                    {
                        commonSubsequences[count++] = subsequences1[i]; // Append the matching subsequence to the commonSubsequences array
                        break; // Break out of the inner loop since a match is found
                    }
                }
            }

            Array.Resize(ref commonSubsequences, count); // Resize the commonSubsequences array to remove any empty elements
            return commonSubsequences;
        }
    }
}


