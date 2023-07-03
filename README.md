# TextPlagiarism
Split the given text into paragraphs using the paragraph separator ('\n' or '\r').
Split the given paragraph and each paragraph in the text into lowercase words using word separators (' ' or '\t').
Initialize a variable to store the maximum common subsequence of words and set it to 0.
Initialize a list to store the common words in the maximum common subsequence.
Iterate through each paragraph in the text.
For each paragraph, perform the Longest Common Subsequence (LCS) algorithm between the words in the given paragraph and the words in the current text paragraph.
Update the maximum common subsequence length if the LCS result is greater than the current maximum.
If the maximum common subsequence length is updated, clear the list of common words and reconstruct the common subsequence by iterating through the LCS matrix.
Return the maximum common subsequence length as the plagiarism similarity value.

# Usage
You can find the code under TextPlagiarism -> TextPlagiarism.cs.

You have to give in two arrays of integers as input and the size N and it will calculate the result between them.
# Functions 
#### SolveValue(string paragraph, string text) 
    returns int[]
    Calculates the maximum similarity between a given paragraph and a text.
#### ConstructSolution(string paragraph, string text)
    returns string 
    Constructs a solution by finding common words between a given paragraph and a text.
#### WordsFromParagraph(string paragraph)
    returns string 
    Splits a paragraph into an array of lowercase words.
#### WordsFromText(string text)
    returns string 
    Splits a text into an array of lowercase words
#### Checker(string[] wordsInParagraph, int maxCommonSubsequence, List<string> commonWords, string[] wordWords, int[,] longestCommonSubsequence)
    returns int
    Updates the maximum common subsequence and reconstructs the common words list.
#### ReconstructCommonSubs(string[] wordsInParagraph, List<string> commonWords, string[] wordWords, int[,] longestCommonSubsequence)
    no return
    Reconstructs the common subsequence of words.
#### LongestCommonSubs(string[] wordsInParagraph, string[] wordWords, int[,] longestCommonSubsequence)
    no return 
    Performs the longest common subsequence algorithm
#### SplitIntoWords(string input)
    returns string
    Splits a string into an array of lowercase words, removing empty entries
#### SplitIntoParagraphs(string input)
    returns string
    Splits a string into an array of paragraphs, removing empty entries
#### CalculateSimilarity(string[] words1, string[] words2)
    returns int
    Calculates the similarity between two arrays of words
