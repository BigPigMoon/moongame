---
title: Бандлы
---

Бандлы являются сборниками компонентов. Бандлы гаранитруют, что сущность всегда будет содержать необходимые компоненты. Каждый бандл содержит метод статичный метод `Create`, который запрашивает необходимые компоненты для этого бандла.

```cs
SpriteBundle.Create(
    world,
    new Sprite(),
    new Transform2D()
    {
        Scale = new Vector2(scaleFactor),
    },
    ballTexture,
    Visibility.Visible
);
```

С помощью метода `Add` вы можете добавить дополнительные компоненты, которые не содержаться в бандле.

```cs
SpriteBundle.Create(
    world,
    new Sprite(),
    new Transform2D()
    {
        Scale = new Vector2(scaleFactor),
    },
    ballTexture,
    Visibility.Visible
).Add(
    new Player()
);
```

Все бандлы движка представлены в разделе Бандлы
