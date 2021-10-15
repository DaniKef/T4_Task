//Гуренко Даниил
// Вариант 5
//Создать консольное приложение, удовлетворяющее следующим требованиям:
//Использовать возможности ООП: абстракция – классы(перечисления, структуры, записи).
//Каждый класс должен иметь отражающее смысл название и информативный состав.
//Предусмотреть различные варианты инициализации экземпляров, наличие статических членов, использование свойств и индексаторов.
//При кодировании должны быть использованы соглашения об оформлении кода С# code convention.
//Классы должны быть грамотно разложены по файлам проекта.
//Консольное меню должно быть минимальным.
//Использовать механизм обработки исключительных ситуаций.
////////////////////////////////////////////////////////////////////////////////////////////////
//Заказ.В сущностях(типах) хранится информация о заказах магазина и товарах в них.
//Для заказа необходимо хранить:
//— номер заказа;
//— товары в заказе;
//— дату поступления.
//Для товаров в заказе необходимо хранить:
//— товар;
//— количество.
//Для товара необходимо хранить:
//— название;
//— описание;
//— цену.
//Вывести полную информацию о заданном заказе.
//Вывести номера заказов, сумма которых не превосходит заданную и количество различных товаров равно заданному.
//Вывести номера заказов, содержащих заданный товар.
//Вывести номера заказов, не содержащих заданный товар и поступивших в течение текущего дня.
//Сформировать новый заказ, состоящий из товаров, заказанных в текущий день.
//Удалить все заказы, в которых присутствует заданное количество заданного товара.

using System;
using System.Collections.Generic;
using VariantC.TaskClasses;
using VariantC.Program;

namespace VariantC
{
    class MainClass
    {
        static void Main(string[] args)
        {
            var AppleProduct = new Product();
            var TableProduct = new Product();
            var MouseProduct = new Product();
            var TShirtProduct = new Product("Футболка", "Синяя футболка, xl", 450);//создание продуктов
            AppleProduct.CreateProduct("Яблоки", "Свежие яблоки \"Малинка\"", 15.60);
            TableProduct.CreateProduct("Стол", "Лучший в мире стол", 2100);
            MouseProduct.CreateProduct("Мышь", "Logitech. Хорошее качество.", 800); //создание продуктов

            List<ProductInOrder> productsOrder = new List<ProductInOrder>(); // для составления товаров, список товаров
            List<Order> allOrders = new List<Order>(); // список всех заказов
           
            productsOrder.Add(new ProductInOrder(AppleProduct, 55));// добавить товар в список
            productsOrder.Add(new ProductInOrder(TableProduct, 3));// добавить товар в список
            var myOrder = new Order(83444, 14, productsOrder);// создать заказ
            allOrders.Add(myOrder);// добавить заказ в список  //1 ЗАКАЗ//

            productsOrder.Clear(); //очистить список товаров, чтоб составить заново для нового заказа
            productsOrder.Add(new ProductInOrder(TShirtProduct, 5)); //Опять Заполнение
            var tShirtsOrder = new Order(80111, 15, productsOrder);
            allOrders.Add(tShirtsOrder); //2 ЗАКАЗ//

            productsOrder.Clear();
            productsOrder.Add(new ProductInOrder(MouseProduct, 7));
            productsOrder.Add(new ProductInOrder(TShirtProduct, 10));
            productsOrder.Add(new ProductInOrder(TableProduct, 1));
            var bigOrder = new Order(90999, 15, productsOrder);
            allOrders.Add(bigOrder); //3 ЗАКАЗ//

            productsOrder.Clear();
            productsOrder.Add(new ProductInOrder(AppleProduct, 20));
            productsOrder.Add(new ProductInOrder(TShirtProduct, 2));
            var someNewOrder = new Order(10000, 16, productsOrder);
            allOrders.Add(someNewOrder);//4 ЗАКАЗ//

            for (int i = 0; i< allOrders.Count;i++) // Вывести все заказы
            {
                allOrders[i].GetInformationAboutOrder();
            } 

            Functions.SearchOrdersWithSumAndCOuntOfProducts(allOrders, 10000, 2); //Вывести номера заказов, сумма которых не превосходит заданную и количество различных товаров равно заданному.
            Functions.SearchThisProduction(allOrders, "Футболка"); // Вывести номера заказов, содержащих заданный товар.
            Functions.SearchNotContainsProductAndToday(allOrders, "Яблоки", 15);//Вывести номера заказов, не содержащих заданный товар и поступивших в течение текущего дня.
            var todayOrder = Functions.CreateOrder(allOrders, 15);//Сформировать новый заказ, состоящий из товаров, заказанных в текущий день.
            allOrders.Add(todayOrder); //5 ЗАКАЗ//

            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < allOrders.Count; i++)// Вывести все заказы
            {
                allOrders[i].GetInformationAboutOrder();
            }

            Functions.RemoveOrdersThisProductThisAmount(ref allOrders, "Футболка", 2);//Удалить все заказы, в которых присутствует заданное количество заданного товара.
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < allOrders.Count; i++)// Вывести все заказы
            {
                allOrders[i].GetInformationAboutOrder();
            }
            Console.WriteLine($"За все время было выполнено {Order.orderCount} заказов."); //Выводит количество всех заказов
            Console.ReadKey();
        }
    }
}
