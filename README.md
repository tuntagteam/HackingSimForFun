# HackingSimForFun

A fictional terminal-game starter written in C#. It simulates dramatic movie-style
commands without scanning, connecting to, or modifying any real system.

## Run

Install the .NET 8 SDK, then run:

```powershell
dotnet run
```

Inside the game, enter `help` to see the available commands.

## Structure

- `Program.cs` wires the game together.
- `Game/TerminalGame.cs` owns the input loop and command routing.
- `Simulation/SimulationEngine.cs` contains fictional game actions.
- `UI/TerminalUi.cs` handles terminal presentation and progress effects.

Add a new command by routing it in `TerminalGame` and implementing its behavior in
`SimulationEngine` (or in a new game system as the project grows).
