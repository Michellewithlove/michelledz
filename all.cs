using System;

namespace MyApplication
{
 class Program
 {
 static void Main(string args)
 {
 Console.Write("Введите трёхзначное число: ");
 int number = int.Parse(Console.ReadLine());

 int unitsCount = number % 10;
 int tensCount = (number / 10) % 10;
 int sumOfDigits = number / 100 + tensCount + unitsCount;
 int productOfDigits = unitsCount * tensCount * number / 100;

 Console.WriteLine($"Число единиц: {unitsCount}");
 Console.WriteLine($"Число десятков: {tensCount}");
 Console.WriteLine($"Сумма цифр: {sumOfDigits}");
 Console.WriteLine($"Произведение цифр: {productOfDigits}");
 }
 }
}