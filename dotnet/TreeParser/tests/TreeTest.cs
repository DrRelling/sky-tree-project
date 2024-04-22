using TreeParser;

namespace Tests;

public class TreeTest
{
   [Fact]
    public void Main_ShouldReturnCorrectResponseForExample()
    {
      var tree = new Tree(new[] { "15","10","22","4","12","18","24" });
      Assert.Equal("4,12,10,18,24,22,15", tree.ToString());
    }

    [Fact]
    public void Tree_ShouldCreateBalancedTree()
    {
        var tree = new Tree(new List<object>() { 1, 2, 3, 4, 5, 6, 7 });

        Assert.Equal("4,5,2,6,7,3,1", tree.ToString());
    }

    [Fact]
    public void Tree_ShouldCreateUnbalancedTree()
    {
        var tree = new Tree(new List<object>() { 1, 2, 3, 4, 5, 6 });

        Assert.Equal("4,5,2,6,3,1", tree.ToString());
    }

    [Fact]
    public void Tree_ShouldReturnNothingIfGivenNothing()
    {
        var tree = new Tree(new List<object>() { });

        Assert.Null(tree.RootNode);
        Assert.Empty(tree.WalkTree());
    }
}