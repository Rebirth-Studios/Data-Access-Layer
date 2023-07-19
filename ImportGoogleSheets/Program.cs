// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using RebirthStudios.Editor;

Stopwatch stopwatch = Stopwatch.StartNew();
stopwatch.Start();
//Console.WriteLine(characterId);
var t = new ImportGoogleSheets();
t.ShowWindow();
Console.WriteLine($"Took {(stopwatch.ElapsedTicks /10000f) /1000f}s");