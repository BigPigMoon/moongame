---
title: Создание сущности
---

Чтобы создать сущность вам необходимо вызвать метод `Create` у экземляра класса `World` (`World` всега присутсвует в любой системе) и в качестве аргументов передать экзэмпляры вашим компонентов.

```cs
public class SomeSystem : ISystem
{
    // Создаем выборку сущностей содержащие компоненты
    private readonly QueryDescription _description = new QueryDescription().WithAll<FooComponent>();

    public void Run(World world)
    {
        world.Create(new FooComponent());
    }
}
```
