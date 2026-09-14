using HackingSimForFun.Simulation;
using HackingSimForFun.UI;

namespace HackingSimForFun.Game;

public sealed class TerminalGame(TerminalUi ui, SimulationEngine simulation)
{
    private bool _isRunning = true;

    public async Task RunAsync()
    {
        ui.ShowBanner();

        while (_isRunning)
        {
            ui.WritePrompt();
            var input = Console.ReadLine();

            if (input is null)
            {
                ui.WriteMuted("Input stream closed. Ending simulation.");
                break;
            }

            var command = input.Trim().ToLowerInvariant();
            if (command.Length == 0)
            {
                continue;
            }

            await ExecuteCommandAsync(command);
        }
    }

    private async Task ExecuteCommandAsync(string command)
    {
        switch (command)
        {
            case "help":
                ui.ShowHelp();
                break;
            case "scan":
                await simulation.RunScanAsync();
                break;
            case "breach":
                await simulation.RunBreachAsync();
                break;
            case "hack":
                await simulation.RunHackAsync();
                break;
            case "decrypt":
                await simulation.RunDecryptAsync();
                break;
            case "clear":
                ui.Clear();
                ui.ShowBanner();
                break;
            case "exit":
            case "quit":
                ui.WriteStatus("Simulation terminated. Stay curious.", ConsoleColor.Cyan);
                _isRunning = false;
                break;
            default:
                ui.WriteStatus($"Unknown command: {command}", ConsoleColor.Red);
                ui.WriteMuted("Type 'help' to list available commands.");
                break;
        }
    }
}
