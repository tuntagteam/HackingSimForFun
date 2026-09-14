namespace HackingSimForFun.UI;

public sealed class TerminalUi
{
    public void ShowBanner()
    {
        WriteStatus("╔══════════════════════════════════════════╗", ConsoleColor.Green);
        WriteStatus("║        NEXUS TERMINAL // GAME MODE       ║", ConsoleColor.Green);
        WriteStatus("╚══════════════════════════════════════════╝", ConsoleColor.Green);
        WriteStatus("FICTIONAL SIMULATION — no real systems are accessed.", ConsoleColor.DarkGray);
        WriteMuted("Type 'help' to view commands.");
        Console.WriteLine();
    }

    public void ShowHelp()
    {
        WriteStatus("AVAILABLE SIMULATION COMMANDS", ConsoleColor.Cyan);
        Console.WriteLine("  help     Show this command list");
        Console.WriteLine("  scan     Discover fictional sandbox nodes");
        Console.WriteLine("  breach   Run a simulated training-vault breach");
        Console.WriteLine("  decrypt  Decode a randomly generated game payload");
        Console.WriteLine("  clear    Clear and redraw the terminal");
        Console.WriteLine("  exit     End the game");
    }

    public void WritePrompt()
    {
        SetColor(ConsoleColor.Green);
        Console.Write("nexus@sim:~$ ");
        Console.ResetColor();
    }

    public void WriteStatus(string message, ConsoleColor color)
    {
        SetColor(color);
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteMuted(string message) => WriteStatus(message, ConsoleColor.DarkGray);

    public async Task ShowProgressAsync(string label, int steps, int delayMilliseconds)
    {
        Console.Write($"{label,-12} [");

        for (var i = 0; i < steps; i++)
        {
            await Task.Delay(delayMilliseconds);
            SetColor(ConsoleColor.Green);
            Console.Write("■");
            Console.ResetColor();
        }

        Console.WriteLine("] 100%");
    }

    public void Clear()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.WriteLine();
        }
    }

    private static void SetColor(ConsoleColor color)
    {
        if (!Console.IsOutputRedirected)
        {
            Console.ForegroundColor = color;
        }
    }
}
