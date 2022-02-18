using System.Text;

namespace CodingDojo;

/**
 * Word Wrap Kata.
 * Copyright (c) 2011, Peter Kofler, licensed under BSD License.
 * adapted from: http://www.code-cop.org/sourcecode/wordwrap/a20110716/WordWrapLoopBuffer.java
 */
public class WordWrapKoflerLoopBuffer : IWordWrap
{
    private const char Blank = ' ';

    public string Wrap(string line, int maxLineLen)
    {
        var accumulator = new StringBuilder(CalcMaxSize(line.Length, maxLineLen));
        accumulator.Append(line);

        var pos = 0;
        var inserted = 0;
        while (pos + maxLineLen < line.Length)
        {
            var indexOfBlank = line.LastIndexOf(Blank, pos + maxLineLen);
            if (indexOfBlank > pos - 1)
            {
                accumulator.Insert(inserted + indexOfBlank, Environment.NewLine);
                pos = indexOfBlank + 1;
            }
            else
            {
                accumulator.Insert(inserted + pos + maxLineLen, Environment.NewLine);
                pos += maxLineLen;
                inserted++;
            }
        }

        return accumulator.ToString();
    }

    /**
     * Calc a bigger buffer so we never resize.
     */
    private static int CalcMaxSize(int lineLen, int maxLineLen)
    {
        var maxCharsAdded = lineLen / maxLineLen;
        return lineLen + maxCharsAdded;
    }

    /*
     * Like optimized loop solution, but
     * 1 Strings are created
     * 1 StringBuilders are created
     * -> constant objects created
     */

}
