using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantA
{
    class Realization
    {
        public static void EmitGivenWord(string line, string word) // выделять введенное слово в строке
        {
            string tempLine = line.ToLower(); // новая строка с мал. буквами 
            string tempWord = word.ToLower();
            List<int> positions = new List<int>(); // список, где индексы начала слов, которые ищем
            int index = tempLine.IndexOf(tempWord); // ищет первый индекс
            while(index!=-1) // ищет все остальные индексы
            {/////////
                positions.Add(index); //добавить индекс в лист
                index = tempLine.IndexOf(tempWord, index + tempWord.Length);// если возвращает -1 - конец цикла 
            }/////////
            int stop = 0; // переменная индекса, когда надо остановить выводить выделяемый текст
            for(int i = 0; i < line.Length; i++)
            {/////////
                if (positions.Contains(i))
                {
                    stop = i + tempWord.Length; // остановится после начала + длина слова
                    Console.ForegroundColor = ConsoleColor.Red; // буквы в красный
                }
                Console.Write(line[i]);
                if(i == stop) // остановится
                {
                    Console.ForegroundColor = ConsoleColor.White; // вернуть белый
                }
            }/////////
        }
        public static StringBuilder ReturnWithoutVerbs(string line) // Удаляет глаголы из строки
        {
            string[] endsOfVerbs = new string[] {"ать","ять","ить","уть","ешь","ишь","тся", "ться","ит"}; // глаголы
            StringBuilder lineWithoutVerbs = new StringBuilder(); // для строки без глаголов
            line = line.Replace(",", " ,"); 
            line = line.Replace(".", " .");
            string[] tempLine = line.Split(' ');
            for (int i = 0; i < tempLine.Length; i++) // проверяю каждое слово
            {/////////
                bool check = false;
                for (int j = 0; j < endsOfVerbs.Length; j++) // проверяю каждое окончание
                {
                    if (tempLine[i].EndsWith(endsOfVerbs[j]))// если есть окончание из массива
                    {
                        check = true;
                    }
                }
                if(!check) // если не глагол - добавить
                lineWithoutVerbs.Append(tempLine[i] + " ");
            }/////////
            return lineWithoutVerbs;
        }
        private static bool DoHaveSamePart(string first, string second, out int firstBegin, out int firstEnd,
            out int secondBegin, out int secondEnd) // принимает 2 строки и проверяет на общую часть
        {// превые 2 параметра - 2 слова, остальное - индекс начала основания и длина общей части 1 слова и второго
            int lenghtFirst = first.Length; // длина первого слова 
            int lenghtSecond = second.Length; // длина второго
            int[,] mas = new int[lenghtFirst, lenghtSecond]; // массив из длин слов
            int maxValue = 0; // максимальное значение повторений
            int maxI = 0; // нужно чтоб найти индекс начала наибольшего совпадения первого слова 
            int maxJ = 0;//второго
            for (int i = 0; i<lenghtFirst; i++) //по 1 слову
            {
                for (int j = 0; j < lenghtSecond; j++) //по второму
                {
                    if(first[i] == second[j]) // если буквы равны
                    {
                        mas[i, j] = (i == 0 || j == 0) ? 1 : mas[i - 1, j - 1] + 1; // если выбранный элемент в матрице ==0 присваивается
                                                                                    // значение 1(т.е первое совпадение), а если нет - значит совпадение продолжается,
                                                                                    // оно идет по диагонале и увеличивается +=1, если совпадения прекратились = следующий элемент
                                                                                    // по диагонали ==0, наибольшее общее будет равно наидольшому увеличению на 1: 0 1 2 3 4 0
                        if (mas[i,j]>maxValue) // присвоить наибольшее
                        {
                            maxValue = mas[i, j];
                            maxI = i; // для 1 слова для формулы
                            maxJ = j; // для второго
                        }
                    }
                }
            }
            if (maxValue < 3) // если совпадений меньше 3 - не учитывать
            {
                firstBegin = 0;
                firstEnd = 0;
                secondBegin = 0;
                secondEnd = 0;
                return false;
            }
            else // иначе
            {
                firstBegin = maxI + 1 - maxValue; // присвоить индекс начала совпадения
                firstEnd = maxValue; // длина совпадения
                secondBegin = maxJ + 1 - maxValue;// для второго слова
                secondEnd = maxValue;
                return true;
            }
        }
        private static void PrintWord(string first, int firstBegin,int firstEnd) // написать слово с разделением на префиксы основания окончания
        { // принимает слово, индекс начала совпадения и длину совпадения
            int checkPrefix = 0; // для проверки на префикс
            for (int i = 0; i < first.Length; i++) // проходит по каждому символу в строке
            {
                if (i < firstBegin && checkPrefix == 0) // если начало совпадения(основания) > 0 , значит есть префикс
                {
                    Console.Write(" Префикс: ");
                    checkPrefix++;
                }
                if (i == firstBegin) Console.Write(" Основание: "); // пришла очерь основания
                if (i == firstBegin + firstEnd) Console.Write(" Окончание: "); // пришла очередь окончания
                Console.Write(first[i]);
            }
            Console.WriteLine();
        }
        public static void BreakIntoPieces(string line) // Разбивает слова в строке на части
        {
            int firstBegin = 0, firstEnd = 0, secondBegin = 0, secondEnd = 0; // для индексов начал и длин оснований
            List<int> indexes = new List<int>(); // помещаются индексы слов, которые уже были, чтоб не было повторений
            line = line.Replace(",", " ,");
            line = line.Replace(".", " .");
            string[] tempLine = line.Split(' ');
            for (int i = 0; i < tempLine.Length; i++) //проверяет слова подряд в 2 циклах
            {
                int iRepeat = 0; // повторений не было == 0 
                for (int j = 0; j < tempLine.Length; j++)
                {
                    if (i == j || indexes.Contains(i) || indexes.Contains(j)) continue; // если проверяется одно и то же слово, или список содержит индекс слова которое было
                    if (DoHaveSamePart(tempLine[i],tempLine[j], out firstBegin, out firstEnd, out secondBegin, out secondEnd)) // вызвать метод на общую часть
                    {
                        if(iRepeat == 0) // если повторений не быо, можно записать оба слова, т.к слово с индеса i проверяется первый раз 
                        {
                            PrintWord(tempLine[i], firstBegin, firstEnd);
                            PrintWord(tempLine[j], secondBegin, secondEnd);// написать слово
                            iRepeat++; // повторение было
                        }
                        else
                        {
                            PrintWord(tempLine[j], secondBegin, secondEnd); // если было повторение 1 из слов, писать одно
                        }
                        indexes.Add(j); //добавить индекс слова из массива слов
                    }
                }
                indexes.Add(i); //добавить индекс
            }

        }
    }
}
