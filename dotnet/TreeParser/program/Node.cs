namespace TreeParser
{
  public class Node
  {
    public object Value { get; set; }
    public List<Node> Children { get; private set; } = new List<Node>();
    public Node? Parent { get; private set; }

    public Node(object value, Node? parent)
    {
      Value = value;
      Parent = parent;
    }

    public Node AddChild(object value)
    {
      var newChild = new Node(value, this);
      Children.Add(newChild);
      return newChild;
    }
  }
}