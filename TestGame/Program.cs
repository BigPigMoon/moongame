using System.IO;
using GameEngine;
using GameEngine.Resource;
using Microsoft.Xna.Framework;
using TestGame;

var currentDirectory = Directory.GetCurrentDirectory(); // Получаем текущий рабочий каталог
var absolutePath = Path.GetFullPath(Path.Combine(currentDirectory, "Content")); // Получаем абсолютный путь

var app = new App(absolutePath);

WindowRes.Instance.SetParams("Test game", 1600, 900, true);
WindowRes.Instance.SetClearColor(Color.Cyan);
app.AddPlugin<TestDrawingPlugin>();

app.Run();
