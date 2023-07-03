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


# Test cases

![TP1](https://github.com/playboikairoo/TextPlagiarism/assets/103595234/4d1bce18-c67e-4562-b17e-c5a30cd88d11)

![TP2](https://github.com/playboikairoo/TextPlagiarism/assets/103595234/4b982341-6595-49a6-b17b-c9a2abeb8782)


# Contributing
Contributions to this library are welcome! If you find a bug or have a feature request, please open an issue on the GitHub repository.

# Contact
If you have any questions or concerns about this library, please feel free to contact me at alhusseingomma194@gmail.com
