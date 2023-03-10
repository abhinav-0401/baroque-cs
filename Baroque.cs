namespace Baroque;

public class Baroque
{
    static bool hadError = false;

    public static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine("Usage: baroque [script]");
            Environment.Exit(64);
        }
        else if (args.Length == 1)
        {
            RunFile(args[0]);
        }
        else
        {
            RunPrompt();
        }
    }

    private static void RunFile(string path)
    {
        string text = System.IO.File.ReadAllText(path);
        Run(text);

        // Indicate an error in the exit code
        if (hadError) Environment.Exit(65);
    }

    private static void RunPrompt()
    {
        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();

            if (line == null)
            {
                break;
            }
            else if (line == "exit")
            {
                Environment.Exit(0);
            }

            Run(line);
            hadError = false;
        }
    }

    private static void Run(string source)
    {
        Scanner scanner = new Scanner(source);
        List<Token> tokens = scanner.ScanTokens();

        foreach (var token in tokens)
        {
            Console.WriteLine(token.ToString());
        }
    }

    public static void Error(int line, string message)
    {
        Report(line, "", message);
    }

    private static void Report(int line, string where, string message)
    {
        Console.WriteLine("[line {0}] Error{1}: {2}", line, where, message);
        hadError = true;
    }


}