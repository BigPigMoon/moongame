---
title: Плагины
---

Плагины в рамках MoonGame являются сборником [систем](/docs/engine/systems) или других плагинов.

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
