namespace TreeParser
{
  public class Tree
  {
    /// <summary>
    /// Reference to the root node, which holds references to all child nodes.
    /// </summary>
    public Node? RootNode { get; }

    /// <summary>
    /// Delimiter for joining nodes when calling ToString()
    /// </summary>
    private readonly char Delimiter;

    public Tree(IEnumerable<object> inputs, char delimiter = ',')
    {
      Delimiter = delimiter;

      if (!inputs.Any())
      {
        return;
      }

      RootNode = new Node(inputs.ElementAt(0), null);

      BuildTree(inputs.Skip(1));
    }

    /// <summary>
    /// Override ToString to return a convenient string representation of the tree.
    /// Child nodes first.
    /// </summary>
    /// <returns>String representation of tree</returns>
    public override string ToString()
    {
      return string.Join(Delimiter, WalkTree().Select(n => n.ToString()));
    }

    /// <summary>
    /// Walk down the tree collecting nodes in the order specified in the assignment
    /// and return an IEnumerable of the values.
    /// </summary>
    /// <returns>An IEnumberable of the values for each node</returns>
    public IEnumerable<object> WalkTree()
    {
      if (RootNode == null)
      {
        return new List<string>();
      }

      var nodes = new List<Node>();
      var unexpandedNodes = new Stack<Node>();

      unexpandedNodes.Push(RootNode);

      while (unexpandedNodes.Any())
      {
        var nextNode = unexpandedNodes.Pop();
        nodes.Add(nextNode);
        nextNode.Children.ForEach(unexpandedNodes.Push);
      }

      return nodes.Select(n => n.Value).Reverse();
    }

    /// <summary>
    /// Build the tree structure from an IEnumerable of input values.
    /// </summary>
    /// <param name="inputs">An IEnumberable of input values to turn into nodes</param>
    private void BuildTree(IEnumerable<object> inputs)
    {
      if (RootNode == null)
      {
        return;
      }

      var parents = new Queue<Node>();
      parents.Enqueue(RootNode);

      var unprocessedInputs = new Queue<object>(inputs);

      while (unprocessedInputs.Any())
      {
        var nextParent = parents.Dequeue();

        var firstChild = nextParent.AddChild(unprocessedInputs.Dequeue());
        parents.Enqueue(firstChild);

        if (unprocessedInputs.TryDequeue(out var secondChildCalue))
        {
          var secondChild = nextParent.AddChild(secondChildCalue);
          parents.Enqueue(secondChild);
        }
      }
    }
  }
}
