using System;
using System.Collections.Generic;
using System.IO;

namespace Lab03
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      int[] intArray = { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
      // this is where i'll call all the methods i write
      // new method for each challenge

      challengeOne(); //works

      // challengeTwo(); //works

      // challengeThree(); //works...whew chile

      // challengeFour(intArray); // works

      // challengeFive(intArray); // works 

      // string fileName = "../words.txt";
      // string message = "Hey, i need to be added to a new file";
      // string wordToChange = "new";
      // string whatToChangeTo = "super cool";
      // challengeSix(message); // works

      // challengeSeven(fileName); // works

      // challengeEight(fileName, wordToChange, whatToChangeTo); //works
      
      // string nineMessage = "This is a message for challenge nine";
      // challengeNine(nineMessage); // works
    }

    public static string[] challengeNine(string message)
    {
      //input a sentence
      var wordsInMessage = new Dictionary<string, int>();
      string[] messageArr = message.Split(" ");
      string[] messageAndValueArr = new string[messageArr.Length];
      foreach (string word in messageArr)
      {
        wordsInMessage.Add(word, word.Length);
      }
      string[] mostCharacters = new string[2];
      // int mostChars = 1;

      // foreach (var messageWord in wordsInMessage)
      // {
      //   if (messageWord.Value > mostChars)
      //   {
      //     // mostChars = messageWord.Value;
      //     mostCharacters[0] = messageWord.Key;
      //     mostCharacters[1] = Convert.ToString(messageWord.Value);
      //   }
      //   Console.Write($"{messageWord.Key}: {messageWord.Value}");
      // }
      int counter = 0;
      foreach (var messageWord in wordsInMessage)
      {
        if (counter == messageArr.Length - 1)
          messageAndValueArr[counter] = messageWord.Key + ": " + messageWord.Value + ".";
        else
          messageAndValueArr[counter] = messageWord.Key + ": " + messageWord.Value + ", ";
        counter++;
      }
      foreach (string value in messageAndValueArr)
        Console.Write(value);
      return messageAndValueArr;

      //return array with the word and number of characters each word has
    }

    public static void challengeEight(string fileName, string wordToChange, string whatToChangeTo)
    {
      string textFromFile = File.ReadAllText(fileName);
      string[] textArr = textFromFile.Split(" ");
      int posToChange = 0;
      for (int i = 0; i < textArr.Length; i++)
      {
        if (textArr[i] == wordToChange)
        {
          posToChange = i;
          textArr[posToChange] = whatToChangeTo;
        }
      }

      challengeSix(string.Join(" ", textArr), fileName);
    }

    public static void challengeSeven(string fileName)
    {
      // read the file from challenge six
      string textFromFile = File.ReadAllText(fileName);
      // output it to the console
      Console.WriteLine(textFromFile);
    }

    public static void challengeSix(string message, string fileName)
    {
      // input a word
      // save that word to an external file named words.txt


      using (StreamWriter writer = new StreamWriter(fileName))
      {
        try
        {
          writer.Write(message);
        }
        catch (System.Exception e)
        {
          Console.WriteLine(e.Message);
          throw;
        }
        finally
        {
          writer.Close();
        }
      }

    }

    public static int challengeFive(int[] intArray)
    {
      int biggestInt = int.MinValue;
      // write a method that finds the max value in the array
      // may not use .Sort()
      foreach (int num in intArray)
      {
        if (num > biggestInt)
          biggestInt = num;
      }

      return biggestInt;
    }

    public static int challengeFour(int[] intArray)
    {
      // write method that brings in int array and returns num that appears the most times
      var dictionaryOfNums = new Dictionary<int, int>();
      int counter = 1;
      // if no duplicats, return first num in array
      int whatAppearsTheMost = intArray[0];
      foreach (int num in intArray)
      {
        if (dictionaryOfNums.ContainsKey(num))
        {
          //update the property++
          int currentValue = dictionaryOfNums[num];
          dictionaryOfNums[num] = currentValue++;
        }
        else
          // add to dictionary
          dictionaryOfNums.Add(num, 1);
      }
      foreach (var pairing in dictionaryOfNums)
      {
        if (pairing.Value > counter)
        {
          counter = pairing.Value;
          whatAppearsTheMost = pairing.Key;
        }
      }
      Console.Write(whatAppearsTheMost);
      return whatAppearsTheMost;


      // if more than 1 num show up the same amount of times, return the first found
    }

    public static double challengeOne()
    {
      try
      {
        double product = 1;
        Console.WriteLine("Enter 3 numbers: ");
        string[] userResponse = Console.ReadLine().Split();
        if (userResponse.Length < 3)
        {
          return 0;
        }
        else if (userResponse.Length > 3)
        {
          for (int i = 0; i < 3; i++)
          // foreach (string num in userResponse)
          {
            try
            {
              double number = Convert.ToDouble(userResponse[i]);
              product *= number;
            }
            catch (System.Exception)
            {
              Console.WriteLine("Not a valid number. Try again");
              return 0;
              throw;
            }
          }
          Console.WriteLine($"The product of these 3 numbers is: {product}");
          return product;
        }
        else
        {
          foreach (string num in userResponse)
          {
            try
            {
              double number = Convert.ToDouble(num);
              product *= number;
            }
            catch (System.Exception)
            {
              Console.WriteLine("Not a valid number. Try again");
              return 0;
              throw;
            }
          }
          Console.WriteLine($"The product of these 3 numbers is: {product}");
          return product;
        }
      }
      catch (System.Exception)
      {
        Console.Write("Not a valid number");
        return 0;
        throw;
      }
    }


    public static double challengeTwo()
    {
      Console.WriteLine("Enter number between 2-10: ");
      double userNum = Convert.ToDouble(Console.ReadLine());
      double[] userNumArr = new double[(int)userNum];

      if (userNum > 10 || userNum < 2 || userNum == double.NaN)
      {
        Console.WriteLine("You can't follow instructions");
        return 0;
      }
      else
      {
        double sum = 0;
        double average = 1;
        for (int i = 0; i < userNum; i++)
        {
          try
          {
            Console.WriteLine($"{i + 1} of {userNum} - Enter a number: ");
            double inputNum = Convert.ToDouble(Console.ReadLine());
            userNumArr[i] = inputNum;
          }
          catch (Exception)
          {
            Console.WriteLine("That was not a valid number. Try again");
            return 0;
            // throw;
          }
        }
        foreach (double num in userNumArr)
          sum += num;
        average = sum / userNumArr.Length;
        Console.Write(average);
        return average;
      }

    }

    public static void challengeThree()
    {
      // i wanna make a diamond
      // lets make a triangle first
      //one on top
      // increments by 2
      // nine on bottom

      int width = 9;
      int space = 5;
      //top
      for (int i = 0; i <= width; i += 2)
      {
        for (int k = 1; k <= space - i + 2; k += 2)
          Console.Write(" ");
        for (int k = 0; k < space; k++)
          Console.Write(" ");
        for (int j = 0; j <= i; j++)
        {
          Console.Write("*");
        }
        Console.Write("\n");
      }
      //bottom
      for (int i = width - 3; i >= 0; i -= 2)
      {
        for (int k = 1; k <= space * 3 - i + 2; k += 2)
          Console.Write(" ");
        for (int j = i; j >= 0; j--)
        {
          Console.Write("*");
        }
        Console.Write("\n");
      }
    }
  }
}
