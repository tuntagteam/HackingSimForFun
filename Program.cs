using HackingSimForFun.Game;
using HackingSimForFun.Simulation;
using HackingSimForFun.UI;

var ui = new TerminalUi();
var simulation = new SimulationEngine(ui);
var game = new TerminalGame(ui, simulation);

await game.RunAsync();
