/* There are three issues in this code, but they are more subtle and structural */
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HangmanGame hangmanGame = new HangmanGame();
        hangmanGame.PlayGame();
    }
}

class HangmanGame
{
    private string[] words = { "programming", "hangman", "computer", "developer", "code" };
    private string selectedWord;
    private char[] guessedWord;
    private int attemptsLeft;
    private List<char> incorrectLetters;
    
    public HangmanGame()
    {
        Random random = new Random();
        selectedWord = words[random.Next(words.Length)];
        guessedWord = new char[selectedWord.Length];
        attemptsLeft = 6;
        incorrectLetters = new List<char>();
    }
    
    public void PlayGame()
    {
        for (int i = 0; i < selectedWord.Length; i++)
        {
            guessedWord[i] = '_';
        }

        while (attemptsLeft > 0)
        {
            DisplayGameStatus();
            Console.Write("Enter a letter: ");
            char guessedLetter = Console.ReadKey().KeyChar;
            
            if (selectedWord.Contains(char.ToLower(guessedLetter)))
            {
                UpdateGuessedWord(guessedLetter);
            }
            else if (!incorrectLetters.Contains(guessedLetter))
            {
                attemptsLeft--;
                incorrectLetters.Add(guessedLetter);
            }

            if (Array.IndexOf(guessedWord, '_') == -1)
            {
                Console.WriteLine("\nCongratulations! You guessed the word: " + selectedWord);
                return;
            }
        }

        Console.WriteLine("\nSorry! You ran out of attempts. The word was: " + selectedWord);
    }

    private void DisplayGameStatus()
    {
        Console.Clear();
        Console.WriteLine("Hangman Game");
        Console.WriteLine("Word: " + new string(guessedWord));
        Console.WriteLine("Attempts Left: " + attemptsLeft);
        Console.Write("Incorrect Letters: ");
        foreach (char letter in incorrectLetters)
        {
            Console.Write(letter);
        }
        Console.WriteLine();
    }

    private void UpdateGuessedWord(char letter)
    {
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (char.ToLower(selectedWord[i]) == char.ToLower(letter))
            {
                guessedWord[i] = selectedWord[i];
            }
        }
    }
}
