---
title: Системы
---

Системы содержат логику и взаимодействую с [сущностями](/engine/enity) имеющими необходимые [компоненты](/engine/components).

Чтобы реализовать систему, необходимо создать новый класс и наследовать его от класса `ISystem`.

```cs
public class SomeSystem : ISystem
{
    // Создаем выборку сущностей содержащие компоненты
    private readonly QueryDescription _description = new QueryDescription().WithAll<FooComponent>();

    public void Run(World world)
    {
        world.Query(in _description, (ref FooComponent component) =>
        {
            // Производим какие-нибудь манипуляция над нашим компонентом
        });
    }
}
```

После реализации системы ее необходимо зарегистрировать в приложении или в [плагине](/engine/plugins).

```cs
app.AddSystem<OnUpdate, SomeSystem>();
```

Метод `AddSystem` принимает 2 класса в шаблонах. Первый обозначает при каком действии система будет вызываться, второй наша новая система.

Всего классов действий существует:

- `OnStart` - при инициализации приложения
- `OnLoad` - при загрузке контента приложения
- `OnUpdate` - при каждом обновлении кадра
- `OnDraw` - при каждой отрисовки кадра
