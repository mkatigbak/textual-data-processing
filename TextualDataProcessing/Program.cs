using System;
using System.Collections.Generic;
using System.Linq;

namespace TextualDataProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* TEXTUAL DATA PROCESSING - MARK KATIGBAK */


            // INPUT TEXT
            Console.WriteLine("Enter a paragraph of text:");
            string input = Console.ReadLine();

            // CALCULATE WORD COUNT
            string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '/' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;

            // CALCULATE VOWEL COUNT
            int vowelCount = input.Count(c => "aeiouAEIOU".Contains(c));

            // CALCULATE WORD FREQUENCY
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string word in words)
            {
                // HANDLE "HIS/HER" CASE
                if (word.Equals("his/her", StringComparison.OrdinalIgnoreCase))
                {
                    // INCREMENT COUNTS FOR "HIS" AND "HER" SEPARATELY
                    if (wordFrequency.ContainsKey("his"))
                    {
                        wordFrequency["his"]++;
                    }
                    else
                    {
                        wordFrequency["his"] = 1;
                    }

                    if (wordFrequency.ContainsKey("her"))
                    {
                        wordFrequency["her"]++;
                    }
                    else
                    {
                        wordFrequency["her"] = 1;
                    }
                }
                else
                {
                    // REGULAR WORD FREQUENCY COUNT
                    if (wordFrequency.ContainsKey(word))
                    {
                        wordFrequency[word]++;
                    }
                    else
                    {
                        wordFrequency[word] = 1;
                    }
                }
            }

            // OUTPUT RESULTS
            Console.WriteLine($"Word Count: {wordCount}");
            Console.WriteLine($"Vowel Count: {vowelCount}");
            Console.WriteLine("Word Frequency Count:");
            Console.WriteLine("\tWordFrequency");

            // CALCULATE COLUMN WIDTHS FOR PROPER ALIGNMENT
            int maxWordLength = wordFrequency.Keys.Max(w => w.Length); // LONGEST WORD LENGTH

            foreach (var kvp in wordFrequency.OrderBy(kvp => kvp.Key))
            {
                // PRINT WORDS WITH RIGHT ALIGNMENT, ALIGNING COUNTS NEATLY
                Console.WriteLine($"{kvp.Key.PadLeft(maxWordLength)}\t{kvp.Value}");
            }
        }
    }
}
