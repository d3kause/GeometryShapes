# Задание 1

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным

****************Комментарии к решению:****************

Первично хотелось реализовать задачу через интерфейс `IAreaCalculable`, который содержал бы метод `GetArea()`, но было решено отказаться от этой идеи в пользу базового абстрактного класса, реализующего указанный интерфейс. 

Так как предметная область чётко не определена, принимаем, что любая геометрическая фигура имеет площадь. Математически это не верно для линий и точки, но это заложенное ограничение, в случае необходимости добавления линий и точек базовый класс для них будет другим, т.к. они содержат иную общую логику.

Базовый класс удобен, если согласно предметной области нам необходимо реализовывать общую логику, например, если нам необходимо работать с фигурами на плоскости, имело бы смысл вынести общие свойства и методы, такие как `Draw()`, `Name`, `Position`. 

Для круга методом создания было выбрано определение радиуса, для треугольника - длины сторон.

От валидации для максимальных значений сторон и радиуса было решено осознанно отказаться, чтобы не создавать условно лишние проверки. 

Добавление новой фигуры осуществляется посредством определения нового наследника базового класса и реализации соответствующего метода `GetArea()`.

В compile-time при данном подходе возможно определение площади для любого наследника `BaseShape` или `IAreaCalculable`

****************Возникшие проблемы:**************** вопросы ограничений размерности фигур и точности вычислений, так как числа с плавающей точкой всё-таки имеют погрешность. Можно бы было использовать тип `decimal`, но это кажется некорректным для этой задачи.

# Задание 2

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 

Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

****************Решение:****************

```rb
SELECT
  products.name, categories.name
FROM
  products
LEFT JOIN
  productCategories
    ON products.id = productCategories.productId
LEFT JOIN
  categories
    ON categories.id = productCategories.categoryId;
```
