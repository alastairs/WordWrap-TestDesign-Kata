using System.Text;

namespace CodingDojo;

/**
 * Word Wrap Kata.
 * Copyright (c) 2011, Peter Kofler, licensed under BSD License.
 * adapted from: http://www.code-cop.org/sourcecode/wordwrap/a20110716/WordWrapLoop.java
 */
public class WordWrapKoflerLoop : IWordWrap
{
    private const char Blank = ' ';

    public string Wrap(string line, int maxLineLen)
    {
        var accumulator = new StringBuilder();
        var remainingLine = line;
        while (remainingLine.Length > maxLineLen)
        {
            var indexOfBlank = remainingLine.LastIndexOf(Blank, maxLineLen);
            int split;
            int offset;
            if (indexOfBlank > -1)
            {
                split = indexOfBlank;
                offset = 1;
            }
            else
            {
                split = maxLineLen;
                offset = 0;
            }

            accumulator.Append(remainingLine[..split]);
            accumulator.Append(Environment.NewLine);
            remainingLine = remainingLine[(split + offset)..];
        }

        accumulator.Append(remainingLine);
        return accumulator.ToString();
    }

    /*
     * Like recursive solution, but
     * 2*n+1 Strings are created
     * 1 StringBuilders are created
     * -> half objects created
     */

}
