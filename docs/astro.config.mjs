import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";

// https://astro.build/config
export default defineConfig({
  site: "https://bigpigmoon.github.io",
  base: "/docs",
  integrations: [
    starlight({
      title: "MoonGame Docs",
      social: {
        github: "https://github.com/bigpigmoon/moongame",
      },
      sidebar: [
        {
          label: "Первые шаги",
          items: [
            // Each item here is one entry in the navigation menu.
            { label: "Первые шаги", link: "/guides/get-started/" },
            { label: "Что такое ECS", link: "/guides/about-ecs/" },
            { label: "Структура проекта", link: "/guides/project-struct/" },
          ],
        },
        {
          label: "Основные элементы движка",
          items: [
            // Each item here is one entry in the navigation menu.
            { label: "Приложение", link: "/engine/app/" },
            { label: "Компоненты", link: "/engine/components/" },
            { label: "Системы", link: "/engine/systems/" },
            { label: "Плагины", link: "/engine/plugins/" },
            { label: "Создание сущности", link: "/engine/enity/" },
            { label: "Бандлы", link: "/engine/bundles/" },
            { label: "Ресурсы", link: "/engine/resourses/" },
          ],
        },
        {
          label: "Компоненты",
          autogenerate: { directory: "components" },
        },
        {
          label: "Бандлы",
          autogenerate: { directory: "bundles" },
        },
      ],
    }),
  ],
});
