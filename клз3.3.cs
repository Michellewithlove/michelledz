using System;

public class ComplexNumber // Класс для представления комплексных чисел
{
    public double RealPart { get; } // Действительная часть
    public double ImaginaryPart { get; } // Мнимую часть

    // Конструктор принимает действительную и мнимую часть
    public ComplexNumber(double real, double imaginary)
    {
        RealPart = real;
        ImaginaryPart = imaginary;
    }

    // Оператор сложения для комплексных чисел
    public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
    {
        // Создаем новое комплексное число, складывая соответствующие части
        return new ComplexNumber(left.RealPart + right.RealPart, left.ImaginaryPart + right.ImaginaryPart);
    }

    // Оператор умножения для комплексных чисел
    public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
    {
        return new ComplexNumber(
            left.RealPart * right.RealPart - left.ImaginaryPart * right.ImaginaryPart,
            left.RealPart * right.ImaginaryPart + left.ImaginaryPart * right.RealPart);
    }

    // Оператор деления для комплексных чисел
    public static ComplexNumber operator /(ComplexNumber numerator, ComplexNumber denominator)
    {
        // Вычисляем знаменатель как сумму квадратов действительной и мнимой частей делителя
        double denominatorMagnitude = denominator.RealPart * denominator.RealPart + denominator.ImaginaryPart * denominator.ImaginaryPart;
        
        return new ComplexNumber(
            (numerator.RealPart * denominator.RealPart + numerator.ImaginaryPart * denominator.ImaginaryPart) / denominatorMagnitude,
            (numerator.ImaginaryPart * denominator.RealPart - numerator.RealPart * denominator.ImaginaryPart) / denominatorMagnitude);
    }

    // Метод для возведения комплексного числа в степень
    public ComplexNumber RaiseToPower(int exponent)
    {
        ComplexNumber result = new ComplexNumber(1, 0); // Начальное значение равно 1
        for (int i = 0; i < exponent; i++)
        {
            result *= this; // Умножаем себя на результат
        }
        return result; // Возвращаем результат возведения в степень
    }

    // Метод для вычисления квадратного корня из комплексного числа
    public ComplexNumber SquareRoot()
    {
        double magnitude = Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart); // Модуль
        double angle = Math.Atan2(ImaginaryPart, RealPart); // Аргумент
        return new ComplexNumber(Math.Sqrt(magnitude) * Math.Cos(angle / 2), Math.Sqrt(magnitude) * Math.Sin(angle / 2));
    }
}