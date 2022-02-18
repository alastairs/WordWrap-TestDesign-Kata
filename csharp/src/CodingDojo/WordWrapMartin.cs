namespace CodingDojo;

public class WordWrapMartin : IWordWrap
{

    public string Wrap(string line, int maxLineLen)
    {
        return Wrapper.Wrap(line, maxLineLen);
    }
}

/**
 * This code is copied from https://thecleancoder.blogspot.com/2010/10/craftsman-62-dark-path.html
 */
internal class Wrapper
{
    public static string Wrap(string s, int col)
    {
        return new Wrapper(col).Wrap(s);
    }

    private readonly int _col;

    private Wrapper(int col)
    {
        _col = col;
    }

    private string Wrap(string s)
    {
        if (s.Length <= _col)
            return s;
        var space = s[.._col].LastIndexOf(' ');

        if (space != -1)
            return BreakLine(s, space, 1);

        if (s[_col] == ' ')
            return BreakLine(s, _col, 1);

        return BreakLine(s, _col, 0);
    }

    private string BreakLine(string s, int pos, int gap)
    {
        return s[..pos] + Environment.NewLine + Wrap(s[(pos + gap)..], _col);
    }
}
