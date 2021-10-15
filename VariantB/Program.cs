//Гуренко Даниил
// Вариант 1
//Создать консольное приложение, используя тип кортеж.
//1. Точки. В сущностях (типах) хранится некоторое конечное множество точек с их координатами.
//Вывести точку из множества, наиболее приближенную к заданной.
//Вывести точку из множества, наиболее удаленную от заданной.
//Вывести точки из множества, лежащие на одной прямой с заданной прямой.

using System;

namespace VariantB
{
    class Program
    {
        static void Main(string[] args)
        {
            Points points = new Points(); 
            points.AddPoint(1, 1);//добавить точку
            points.AddPoint(4, 1);
            points.AddPoint(3, 6);
            points.AddPoint(-5, 6);
            points.AddPoint(188, -2);
            points.PrintAllPoints(); // вывести все точки
            points.PrintMostClosePoint(2, 4); // вывести наиболее ближнюю точку, передаваемой точке
            points.PrintMostDistantPoint(2, 4); // вывести наиболее дальнюю точку, передаваемой точке
            points.OnALine((0, 1), (5, 1)); // узнать, есть ли хоть 1 точка на прямой, передаваемой 
            Console.ReadKey();
        }
    }
}
