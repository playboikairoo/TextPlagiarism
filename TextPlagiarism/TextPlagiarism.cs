using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Split the given text into paragraphs using the paragraph separator ('\n' or '\r').
Split the given paragraph and each paragraph in the text into lowercase words using word separators (' ' or '\t').
Initialize a variable to store the maximum common subsequence of words and set it to 0.
Initialize a list to store the common words in the maximum common subsequence.
Iterate through each paragraph in the text.
For each paragraph, perform the Longest Common Subsequence (LCS) algorithm between the words in the given paragraph and the words in the current text paragraph.
Update the maximum common subsequence length if the LCS result is greater than the current maximum.
If the maximum common subsequence length is updated, clear the list of common words and reconstruct the common subsequence by iterating through the LCS matrix.
Return the maximum common subsequence length as the plagiarism similarity value.
To implement the two required functions:

The first function should take the given paragraph and the complete text as input. 
It should internally follow the steps above and return the plagiarism similarity value.

The second function should take the given paragraph and the complete text as input.
It should also follow the steps above, but instead of returning the plagiarism similarity value,
it should return the subsequence of common words (if any) between the given paragraph and the paragraph in the text with the maximum common subsequence. If there is no common subsequence, the function should return null.
*/
namespace Problem
{

    public static class TextPlagiarism
    {
        // Calculates the maximum similarity between a given paragraph and a text
        public static int SolveValue(string paragraph, string text)
        {
            // Split the given paragraph into words
            string[] paragraphWords = SplitIntoWords(paragraph);

            // Split the complete text into paragraphs
            string[] textParagraphs = SplitIntoParagraphs(text);

            // Initialize variable to store the maximum similarity
            int maxSimilarity = 0;

            // Iterate through each paragraph in the text
            foreach (string textParagraph in textParagraphs)
            {
                // Split the current text paragraph into words
                string[] textParagraphWords = SplitIntoWords(textParagraph);

                // Calculate the similarity between the given paragraph and the current text paragraph
                int similarity = CalculateSimilarity(paragraphWords, textParagraphWords);

                // Update the maximum similarity if the current similarity is greater
                maxSimilarity = Math.Max(maxSimilarity, similarity);
            }

            // Return the maximum similarity value
            return maxSimilarity;
        }

        // Constructs a solution by finding common words between a given paragraph and a text
        public static string[] ConstructSolution(string paragraph, string text)
        {
            string[] wordsInText = WordsFromText(text);
            string[] wordsInParagraph = WordsFromParagraph(paragraph);

            // Initialize variables
            int maxCommonSubsequence = 0;
            List<string> commonWords = new List<string>();

            // Iterate through each word in the text
            foreach (string word in wordsInText)
            {
                // Split the current word into lowercase words
                string[] wordWords = word.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Create a matrix to store the longest common subsequence lengths
                int[,] longestCommonSubsequence = new int[wordsInParagraph.Length + 1, wordWords.Length + 1];

                // Perform longest common subsequence algorithm
                LongestCommonSubs(wordsInParagraph, wordWords, longestCommonSubsequence);

                // Check if the current longest common subsequence is greater than the previous maximum
                maxCommonSubsequence = Cheaker(wordsInParagraph, maxCommonSubsequence, commonWords, wordWords, longestCommonSubsequence);
            }

            return commonWords.ToArray();
        }

        // Splits a paragraph into an array of lowercase words
        private static string[] WordsFromParagraph(string paragraph)
        {
            return paragraph.ToLower().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Splits a text into an array of lowercase words
        private static string[] WordsFromText(string text)
        {
            // Split the input text and paragraph into lowercase words
            return text.ToLower().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Updates the maximum common subsequence and reconstructs the common words list
        private static int Cheaker(string[] wordsInParagraph, int maxCommonSubsequence, List<string> commonWords, string[] wordWords, int[,] longestCommonSubsequence)
        {
            if (longestCommonSubsequence[wordsInParagraph.Length, wordWords.Length] > maxCommonSubsequence)
            {
                // Update the maximum common subsequence length and clear the list of common words
                maxCommonSubsequence = longestCommonSubsequence[wordsInParagraph.Length, wordWords.Length];
                commonWords.Clear();

                // Reconstruct the common subsequence
                ReconstructCommonSubs(wordsInParagraph, commonWords, wordWords, longestCommonSubsequence);

                // Reverse the list of common words
                commonWords.Reverse();
            }

            return maxCommonSubsequence;
        }

        // Reconstructs the common subsequence of words
        private static void ReconstructCommonSubs(string[] wordsInParagraph, List<string> commonWords, string[] wordWords, int[,] longestCommonSubsequence)
        {
            int p = wordsInParagraph.Length;
            int h = wordWords.Length;
            while (p > 0 && h > 0)
            {
                if (wordsInParagraph[p - 1] == wordWords[h - 1])
                {
                    commonWords.Add(wordsInParagraph[p - 1]);
                    p--;
                    h--;
                }
                else if (longestCommonSubsequence[p - 1, h] > longestCommonSubsequence[p, h - 1])
                    p--;
                else
                    h--;
            }
        }

        // Performs the longest common subsequence algorithm
        private static void LongestCommonSubs(string[] wordsInParagraph, string[] wordWords, int[,] longestCommonSubsequence)
        {
            for (int i = 0; i <= wordsInParagraph.Length; i++)
            {
                for (int j = 0; j <= wordWords.Length; j++)
                {
                    if (i == 0 || j == 0)
                        longestCommonSubsequence[i, j] = 0;
                    else if (wordsInParagraph[i - 1] == wordWords[j - 1])
                        longestCommonSubsequence[i, j] = longestCommonSubsequence[i - 1, j - 1] + 1;
                    else
                        longestCommonSubsequence[i, j] = Math.Max(longestCommonSubsequence[i - 1, j], longestCommonSubsequence[i, j - 1]);
                }
            }
        }

        // Splits a string into an array of lowercase words, removing empty entries
        private static string[] SplitIntoWords(string input)
        {
            // Split the input into words, removing empty entries
            return input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(word => word.ToLower())
                        .ToArray();
        }

        // Splits a string into an array of paragraphs, removing empty entries
        private static string[] SplitIntoParagraphs(string input)
        {
            // Split the input into paragraphs, removing empty entries
            return input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Calculates the similarity between two arrays of words
        private static int CalculateSimilarity(string[] words1, string[] words2)
        {
            // Create a matrix to store the similarity values
            int[,] similarityMatrix = new int[words1.Length + 1, words2.Length + 1];

            // Iterate through the words of the first sequence
            for (int i = 1; i <= words1.Length; i++)
            {
                // Iterate through the words of the second sequence
                for (int j = 1; j <= words2.Length; j++)
                {
                    // Compare the current words for equality, ignoring case
                    if (string.Equals(words1[i - 1], words2[j - 1], StringComparison.OrdinalIgnoreCase))
                    {
                        // If the words are equal, increment the similarity value
                        similarityMatrix[i, j] = similarityMatrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        // If the words are not equal, take the maximum similarity value from the previous positions
                        similarityMatrix[i, j] = Math.Max(similarityMatrix[i - 1, j], similarityMatrix[i, j - 1]);
                    }
                }
            }

            // Return the final similarity value
            return similarityMatrix[words1.Length, words2.Length];
        }

    }
}