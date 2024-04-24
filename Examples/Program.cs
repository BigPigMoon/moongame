using System.IO;
using GameEngine;
using Examples;
using GameEngine.Plugins;
using GameEngine.Resource;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

var currentDirectory = Directory.GetCurrentDirectory(); // Получаем текущий рабочий каталог
var absolutePath = Path.GetFullPath(Path.Combine(currentDirectory, "Content")); // Получаем абсолютный путь

var app = new App(absolutePath);

WindowRes.Instance.SetParams("Test game", 1600, 900, true);
WindowRes.Instance.SetClearColor(Color.Cyan);

SpriteBatchRes.Instance.SamplerState = SamplerState.PointClamp;
app.AddPlugin<CameraPlugin>();
app.AddPlugin<DefaultPlugins>();
app.AddPlugin<TestAnimPlugin>();

app.Run();