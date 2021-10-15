using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VariantB
{
    public class Points
    {
        List<(int, int)> pointsList = new List<(int, int)>(); //все точки
        public void AddPoint(int x, int y)// добавить точку
        {
            pointsList.Add((x, y));
        }
        public void PrintAllPoints()// вывести все точки
        {
            for(int i = 0; i< pointsList.Count; i++)
            {
                Console.WriteLine($"X: {pointsList[i].Item1} Y: {pointsList[i].Item2}");
            }
        }
        public void PrintMostClosePoint(int x, int y) // найти наиболее ближнюю точку
        {
            (int, int) searchedPoint = (x, y); // точка по которой ищем
            double closedDistanse = Math.Sqrt(Math.Pow(searchedPoint.Item1 - pointsList[0].Item1, 2) +
                    Math.Pow(searchedPoint.Item2 - pointsList[0].Item2, 2)); // длина отрезка, что соединяет 2 точки
            int indexOfPoint = 0; // индекс наиболее ближней точки
            for (int i = 1; i < pointsList.Count; i++) // по всем точкам
            {
                double tempDistance = Math.Sqrt(Math.Pow(searchedPoint.Item1 - pointsList[i].Item1, 2) +
                    Math.Pow(searchedPoint.Item2 - pointsList[i].Item2, 2)); // проверяется расстояние между передавоемой точкой и всеми остальными
                if (tempDistance < closedDistanse)// находить наиболее маленькое расстояние
                {
                    closedDistanse = tempDistance;
                    indexOfPoint = i;// присвоить индекс
                }
            }
            Console.WriteLine($"Наиболее приближенная точка к ({searchedPoint.Item1},{searchedPoint.Item2})" +
                $" - ({pointsList[indexOfPoint].Item1},{pointsList[indexOfPoint].Item2}). Дистанция - {closedDistanse}"); //вывод
        }
        public void PrintMostDistantPoint(int x, int y)// находит наиболее удаленную точку от передаваемой
        {
            (int, int) searchedPoint = (x, y); // то же самое, что и выше, только
            double greatesDistanse = Math.Sqrt(Math.Pow(searchedPoint.Item1 - pointsList[0].Item1, 2) +
                    Math.Pow(searchedPoint.Item2 - pointsList[0].Item2, 2)); 
            int indexOfPoint = 0;
            for (int i = 1; i < pointsList.Count; i++)
            {
                double tempDistance = Math.Sqrt(Math.Pow(searchedPoint.Item1 - pointsList[i].Item1, 2) +
                    Math.Pow(searchedPoint.Item2 - pointsList[i].Item2, 2));
                if (tempDistance > greatesDistanse) //меняется условие
                {
                    greatesDistanse = tempDistance;
                    indexOfPoint = i;
                }
            }
            Console.WriteLine($"Наиболее удаленная точка к ({searchedPoint.Item1},{searchedPoint.Item2})" +
                $" - ({pointsList[indexOfPoint].Item1},{pointsList[indexOfPoint].Item2}). Дистанция - {greatesDistanse}");
        }
        public void OnALine((int, int)firstPoint, (int,int)secondPoint)// проверяет находится ли точка из множества на передаваемой прямой, а прямая - 2 точки
        {
            double AB = Math.Sqrt(Math.Pow(secondPoint.Item1 - firstPoint.Item1, 2) +
                    Math.Pow(secondPoint.Item2 - firstPoint.Item2, 2)); 
            for (int i = 0; i < pointsList.Count; i++)// надо найти расстояние каждой точки от от обеих конечных линий и если выполняется условие, то точка лежит на прямой
            {
                double AP = Math.Sqrt(Math.Pow(pointsList[i].Item1 - firstPoint.Item1, 2) +
                    Math.Pow(pointsList[i].Item2 - firstPoint.Item2, 2)); // считает длины
                double PB = Math.Sqrt(Math.Pow(secondPoint.Item1 - pointsList[i].Item1, 2) +
                   Math.Pow(secondPoint.Item2 - pointsList[i].Item2, 2)); 
                if (AB == AP + PB) // условие
                {
                    Console.WriteLine($"Точка ({pointsList[i].Item1},{pointsList[i].Item2}) находится на " +
                        $"прямой, определенной точками ({firstPoint.Item1},{firstPoint.Item2}) " +
                        $"({secondPoint.Item1},{secondPoint.Item2}) ");
                }
            }
        }
    }
}
