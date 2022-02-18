namespace CodingDojo;

/**
 * This code is adapted from https://github.com/sblausten/word-wrap-kata
 */
public class WordWrapBlausten2 : IWordWrap
{
    public string Wrap(string line, int maxLineLen)
    {
        return WrapImpl(line, maxLineLen);
    }

    private static string WrapImpl(string text, int cols)
    {
        if (cols >= text.Length) return text;
        var colsToSpace = text[..cols].LastIndexOf(' ');
        var actualCols = colsToSpace == -1 ? cols : colsToSpace + 1;
        if (text[cols] == ' ') actualCols = cols + 1;
        return text[..actualCols] + Environment.NewLine + WrapImpl(text[actualCols..], cols);
    }
}
