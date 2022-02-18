using System.Collections.Generic;
using NUnit.Framework;

namespace CodingDojo.Tests;

public class WordWrapTest
{
    private static IEnumerable<IWordWrap> Wrappers() =>
        new IWordWrap[]
        {
            new WordWrapKoflerLoop(),
            new WordWrapKoflerLoopBuffer(),
            new WordWrapKoflerRegex(),
            new WordWrapBlausten(),
            new WordWrapBlausten2(),
            new WordWrapMartin()
        };

    // TODO: write some more test cases like this one
    [TestCaseSource(nameof(Wrappers))]
    public void WrapEmptyString(IWordWrap wrapper)
    {
        Assert.AreEqual("", wrapper.Wrap("", 1));
    }
}
