# ИИ для обороны
Тестовый проект для одноименной задачи из турнира школьной олимпиады НТИ  
https://imcs.dvfu.ru/cats/main.pl?f=problems;cid=1900903

Вам необходимо реализовать класс `CannonAI`. 

```c#
public class CannonAI : ICannonAI {
    // Расстояние на котором находится цель
    public void SetTarget(double distance)
    {
        throw new System.NotImplementedException();
    }

    // Угол наклона в градусах в который нужно установить пушку перед выстрелом
    public double GetShootAngle()
    {
        throw new System.NotImplementedException();
    }

    // Информация о дальности полета снаряда
    public void FeedbackHitDistance(double distance)
    {
        throw new System.NotImplementedException();
    }
}
```
Файл которого находится по пути `Assets/Scripts/CannonAI.cs`

---
Обратите внимание, что при написании решения не следует использовать встроенные в Unity функции. Используйте аналоги из стандартной библиотеки.
