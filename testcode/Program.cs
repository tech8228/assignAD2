using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            string[] inputs = { "abcdda", "abcddda", "abbbcddda", "abbbcdddaabbbcddda", "abbbcdddaaaabbbcddda" };

            string pathOfFolder = @"D:\\FSDcodes\\Githostedprojects\\testfolder";
            int countFiles = CountFilesInFolder(pathOfFolder);
            Console.WriteLine($"Total number of files: {countFiles}");

            Console.WriteLine("Enter the input string:");
            string stringInput = Console.ReadLine();

            string result = RemoveAConsecutiveDuplicates(stringInput);

            Console.WriteLine("Entered: "+stringInput+ " | Output: " + result);


            foreach (string input in inputs)
            {
                string output = RemoveConsecutiveDuplicates(input);
                Console.WriteLine($"Input: \"{input}\" | Output: \"{output}\"");
            }
            Console.ReadLine();
        }

        static string RemoveConsecutiveDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder result = new StringBuilder();
            result.Append(input[0]); // Add the first character

            for (int i = 1; i < input.Length; i++)
            {
                // Check if the current character is different from the previous one
                if (input[i] != input[i - 1])
                {
                    result.Append(input[i]); // Add the character to the result
                }
            }

            return result.ToString();
        }


        static string RemoveAConsecutiveDuplicates(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
                return string.Empty;

            char prev = '\0';
            char prevPrev = '\0';
            bool removedOnce = false;
            string result = string.Empty;

            foreach (char current in stringInput)
            {
                

                
                    if ((current == 'a' || current == 'd')&& current == prev)
                    {
                        if (!removedOnce )
                        {
                            removedOnce = true;
                        }
                        else
                        {

                        result += current;
                        prevPrev = prev;
                        prev = current;
                        removedOnce = false;
                    }
                        
                    
                    }
                    else if (current == 'b')
                    {
                        if (current != prev )
                        {
                            result += current;
                            prevPrev = prev;
                            prev = current;
                        }
                        else 
                        {
                            continue;
                        }
                    }
                    else if (current == 'c')
                    {
                        if (current != prev )
                        {
                            result += current;
                            prevPrev = prev;
                            prev = current;
                        }
                        else 
                        {
                            continue;
                        }
                    }
                    else
                    {
                        result += current;
                        prevPrev = prev;
                        prev = current;
                    }
               

            }



            return result;
        }

        static int CountFilesInFolder(string pathOfFolder)
        {
            // Check if the directory exists
            if (!Directory.Exists(pathOfFolder))
                return 0;

            int count = 0;

            // Get files in the current directory
            string[] files = Directory.GetFiles(pathOfFolder);
            count += files.Length;

            // Recursively traverse subdirectories
            string[] subdirectories = Directory.GetDirectories(pathOfFolder);
            foreach (string subdirectory in subdirectories)
            {
                count += CountFilesInFolder(subdirectory);
            }

            return count;
        }
    }

    
}
