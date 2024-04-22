using TreeParser;

namespace Tests;

public class MainTest
{
    [Fact]
    public void Main_ShouldAcceptValidCommaSeparatedInput()
    {
        Assert.Equal(0, MainClass.Main(new[] { "1,2,3,4" }));
    }

    [Fact]
    public void Main_ShouldAcceptValidSpaceSeparatedInput()
    {
        Assert.Equal(0, MainClass.Main(new[] { "1", "2", "3", "4" }));
    }

    [Fact]
    public void Main_ShouldRejectEmptyInput()
    {
        Assert.Equal(1, MainClass.Main(Array.Empty<string>()));
    }

    [Fact]
    public void Main_ShouldRejectInvalidInput()
    {
        Assert.Equal(1, MainClass.Main(new[] { "abc", "def" }));
    }
}