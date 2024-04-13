---
title: Плагины
---

Плагины в рамках MoonGame являются сборником [систем](/engine/systems) или других плагинов.

Плагин является классом, который должен быть наследован от интерфейса `IPlugin` и реализовать его.

Пример плагина:

```csharp
// SomePlugin.cs
public class SomePlugin : IPlugin
{
    public void Create(App app)
    {
        throw new NotImplementedException();
    }
}
```

После создания плагина его необходимо зарегистрировать. Это можно сделать спомощью метода экземпляра класса `App`.

```csharp
// Program.cs
app.AddPlugin<SomePlugin>();
```

## Стандартные плагины

Стандартные плагины находятся в классе DefaultPlugins, который содержит следующие плагины

- [SpritePlugin](/plugins/sprite)
- [DefaultCameraPlugin](/plugins/camera)

:::tip[Почему ничего не работает]
Чтобы ваша игра начала отображать спрайты, играть музыку, воспроизводить анимации и т.д., вам необходимо подключить `DefaultPlugins` в главном файле вашей игры

```cs
// Program.cs
app.AddPlugin<DefaultPlugins>();
```

:::
