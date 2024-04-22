namespace TreeParser
{
  public class MainClass
  {
    private static readonly char delimiter = ',';

    public static int Main(string[] args)
    {
      var cleanInput = ValidateCleanAndFilterArguments(args);

      if (!cleanInput.Any())
      {
        Console.WriteLine("No valid inputs found, exiting.");
        return 1;
      }

      var tree = new Tree(cleanInput, delimiter);

      Console.WriteLine(tree);

      return 0;
    }

    /// <summary>
    /// Ensure that all arguments passed are valid (integers only for now) and remove any unnecessary spaces.
    /// </summary>
    /// <param name="args">Array of strings from console input</param>
    /// <returns>IEnumerable of valid args</returns>
    private static IEnumerable<string> ValidateCleanAndFilterArguments(string[] args)
    {
      static IEnumerable<string> cleanAndFilterArgs(string[] args) => args.Select(a => a.Trim()).Where(a => int.TryParse(a, out _));

      if (args.Length == 0)
      {
        Console.Error.WriteLine("At least one argument is required");
        return Array.Empty<string>();
      }
      else if (args.Length == 1)
      {
        return cleanAndFilterArgs(args[0].Split(delimiter));
      }
      else
      {
        return cleanAndFilterArgs(args);
      }
    }
  }
}