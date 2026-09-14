using HackingSimForFun.UI;

namespace HackingSimForFun.Simulation;

public sealed class SimulationEngine(TerminalUi ui)
{
    private static readonly string[] NodeNames =
    [
        "ORBITAL-7", "NEON-VAULT", "GHOST-NODE", "CIPHER-ARC", "ECHO-CORE"
    ];

    public async Task RunScanAsync()
    {
        ui.WriteStatus("SIMULATION: scanning fictional sandbox nodes...", ConsoleColor.Yellow);
        await ui.ShowProgressAsync("Mapping", 12, 45);

        var nodeCount = Random.Shared.Next(3, 6);
        for (var i = 0; i < nodeCount; i++)
        {
            var node = NodeNames[Random.Shared.Next(NodeNames.Length)];
            var address = $"SIM-{Random.Shared.Next(1000, 9999)}";
            ui.WriteStatus($"  {address,-10} {node,-12} ONLINE", ConsoleColor.Green);
        }

        ui.WriteMuted($"{nodeCount} fictional nodes discovered. No real network activity occurred.");
    }

    public async Task RunBreachAsync()
    {
        ui.WriteStatus("SIMULATION: initiating training-vault breach...", ConsoleColor.Yellow);
        await ui.ShowProgressAsync("Bypassing", 20, 55);

        var clearance = Random.Shared.Next(1, 10);
        ui.WriteStatus($"ACCESS GRANTED — sandbox clearance level {clearance}", ConsoleColor.Green);
        ui.WriteMuted("Target was fictional; no system was accessed.");
    }

    public async Task RunDecryptAsync()
    {
        ui.WriteStatus("SIMULATION: decoding synthetic cipher block...", ConsoleColor.Yellow);
        await ui.ShowProgressAsync("Decrypting", 16, 60);

        const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        var code = new string(
            Enumerable.Range(0, 12)
                .Select(_ => alphabet[Random.Shared.Next(alphabet.Length)])
                .ToArray());

        ui.WriteStatus($"PAYLOAD: {code[..4]}-{code[4..8]}-{code[8..]}", ConsoleColor.Green);
        ui.WriteMuted("Synthetic payload recovered for game purposes only.");
    }
}
