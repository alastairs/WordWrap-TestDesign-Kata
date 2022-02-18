namespace CodingDojo;

using System;
using System.Collections.Generic;

/**
 * This code is adapted from https://github.com/sblausten/word-wrap-kata
 */
public class WordWrapBlausten : IWordWrap
{
    public string Wrap(string text, int columnLength)
    {
        var textLength = text.Length;
        if (textLength < columnLength) return text;
        var charsArray = text.ToCharArray();
        var textSections = new List<string>();
        var sectionCount = textLength / columnLength;
        var charIndex = 0;

        for (var i = 0; i < sectionCount; i++)
        {
            var section = "";
            var lengthTillLastSpace = charIndex + columnLength;
            Console.WriteLine("1st length " + lengthTillLastSpace);
            while (charsArray[lengthTillLastSpace] != ' ')
            {
                lengthTillLastSpace -= 1;
            }
            var charsInThisSection = lengthTillLastSpace - charIndex;
            Console.WriteLine("2nd length " + lengthTillLastSpace);
            for (var n = 0; n < charsInThisSection; n++)
            {
                section += charsArray[charIndex];
                charIndex++;
            }
            Console.WriteLine("Index " + charIndex);
            textSections.Add(section.Trim());
        }
        Console.WriteLine("Near index " + charIndex);
        Console.WriteLine("Text Length " + textLength);
        var remainingChars = textLength % charIndex;
        Console.WriteLine("Remaining " + remainingChars);
        if (remainingChars > 0)
        {
            var section = "";
            for (var n = 0; n < remainingChars; n++)
            {
                section += charsArray[charIndex];
                charIndex++;
            }
            Console.WriteLine("Final index " + charIndex);
            Console.WriteLine("TotalChars " + charsArray.Length);
            textSections.Add(section.Trim());
        }
        Console.WriteLine(textSections[1]);
        return string.Join(Environment.NewLine, textSections);
    }
}
