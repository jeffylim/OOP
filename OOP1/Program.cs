
using System;

public class RationalNumber
{
    private int _numerator;
    private int _denominator;

    public int Numerator { get { return _numerator; } }
    public int Denominator { get { return _denominator; } }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        _numerator = numerator / gcd;
        _denominator = denominator / gcd;

        if (_denominator < 0)
        {
            _numerator *= -1;
            _denominator *= -1;
        }
    }

    public override string ToString()
    {
        if (_denominator == 1)
        {
            return _numerator.ToString();
        }
        else
        {
            return $"{_numerator}/{_denominator}";
        }
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a._numerator * b._numerator, a._denominator * b._denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a._numerator * b._denominator, a._denominator * b._numerator);
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        return new RationalNumber(-a._numerator, a._denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a._numerator * b._denominator == b._numerator * a._denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a._numerator * b._denominator < b._numerator * a._denominator;
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a._numerator * b._denominator > b._numerator * a._denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return !(a > b);
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return !(a < b);
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    public static RationalNumber Parse(string input)
    {
        string[] parts = input.Split('/');
        if (parts.Length == 1)
        {
            return new RationalNumber(int.Parse(parts[0]), 1);
        }
        else if (parts.Length == 2)
        {
            return new RationalNumber(int.Parse(parts[0]), int.Parse(parts[1]));
        }
        else
        {
            throw new FormatException("Input string is not in a valid format.");
        }
    }

    public static void RunUnitTests()
    {
        RationalNumber a = new RationalNumber(1, 2);
        RationalNumber b = new RationalNumber(2, 3);

        Console.WriteLine(a + b); // вывод результата на консоль
        Console.WriteLine(a - b); // вывод результата на консоль
        Console.WriteLine(a * b); // вывод результата на консоль
        Console.WriteLine(a / b); // вывод результата на консоль
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите первое рациональное число в формате 'числитель/знаменатель':");
        string input1 = Console.ReadLine();
        RationalNumber rational1 = RationalNumber.Parse(input1);

        Console.WriteLine("Введите второе рациональное число в формате 'числитель/знаменатель':");
        string input2 = Console.ReadLine();
        RationalNumber rational2 = RationalNumber.Parse(input2);

        Console.WriteLine("Результаты арифметических операций:");
        Console.WriteLine("Сумма: " + (rational1 + rational2));
        Console.WriteLine("Разность: " + (rational1 - rational2));
        Console.WriteLine("Произведение: " + (rational1 * rational2));
        Console.WriteLine("Деление: " + (rational1 / rational2));
    }
}




//using System;
//using System.Globalization;
//using System.Text;

//// Интерфейс для декоратора
//interface IDateTimeDecorator
//{
//    string Decorate(DateTime dateTime);
//}

//// Базовый класс декоратора
//abstract class DateTimeDecorator : IDateTimeDecorator
//{
//    private readonly IDateTimeDecorator _decorator;

//    protected DateTimeDecorator(IDateTimeDecorator decorator)
//    {
//        _decorator = decorator;
//    }

//    public virtual string Decorate(DateTime dateTime)
//    {
//        return _decorator?.Decorate(dateTime);
//    }
//}

//// Декоратор для добавления произвольных символов
//class SymbolDateTimeDecorator : DateTimeDecorator
//{
//    private readonly string _symbol;

//    public SymbolDateTimeDecorator(IDateTimeDecorator decorator, string symbol) : base(decorator)
//    {
//        _symbol = symbol;
//    }

//    public override string Decorate(DateTime dateTime)
//    {
//        string baseResult = base.Decorate(dateTime);
//        return baseResult + _symbol;
//    }
//}

//// Декоратор для форматирования даты и времени в стиле Европы
//class EuropeanDateTimeDecorator : IDateTimeDecorator
//{
//    public string Decorate(DateTime dateTime)
//    {
//        CultureInfo culture = new CultureInfo("ru-RU");
//        return dateTime.ToString("dd.MM.yyyy HH:mm:ss", culture);
//    }
//}

//// Декоратор для форматирования даты и времени в стиле Америки
//class AmericanDateTimeDecorator : IDateTimeDecorator
//{
//    public string Decorate(DateTime dateTime)
//    {
//        CultureInfo culture = new CultureInfo("en-US");
//        return dateTime.ToString("MM/dd/yyyy hh:mm:ss tt", culture);
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        DateTime currentDateTime = DateTime.Now;

//        StringBuilder result = new StringBuilder();
//        result.AppendLine("Декорированное текущее время:");

//        // Применение декораторов в произвольном порядке и количестве
//        IDateTimeDecorator europeanDecorator = new EuropeanDateTimeDecorator();
//        IDateTimeDecorator americanDecorator = new AmericanDateTimeDecorator();
//        IDateTimeDecorator symbolDecorator = new SymbolDateTimeDecorator(null, " ***");

//        result.AppendLine(europeanDecorator.Decorate(currentDateTime));
//        result.AppendLine(americanDecorator.Decorate(currentDateTime));

//        IDateTimeDecorator combinedDecorator = new SymbolDateTimeDecorator(new AmericanDateTimeDecorator(), " ААА");
//        result.AppendLine(combinedDecorator.Decorate(currentDateTime));

//        Console.WriteLine(result.ToString());
//    }
//}

//using System;
//using System.Collections.Generic;

//public class TreeNode
//{
//    public int Value { get; set; }
//    public List<TreeNode> Children { get; set; }

//    public TreeNode(int value)
//    {
//        Value = value;
//        Children = new List<TreeNode>();
//    }

//    public void PrintChildrenValues()
//    {
//        Console.WriteLine("Дочерние узлы со значением " + Value + ":");
//        foreach (var child in Children)
//        {
//            Console.WriteLine(child.Value);
//            child.PrintChildrenValues(); // Вызов рекурсивной функции для вывода детей вложенных узлов
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Создаем узлы
//        TreeNode root = new TreeNode(1);
//        TreeNode child1 = new TreeNode(2);
//        TreeNode child2 = new TreeNode(3);
//        TreeNode grandchild1 = new TreeNode(4);
//        TreeNode grandchild2 = new TreeNode(5);

//        // Связываем узлы
//        root.Children.Add(child1);
//        root.Children.Add(child2);
//        child1.Children.Add(grandchild1);
//        child2.Children.Add(grandchild2);

//        // Выводим значения детей
//        root.PrintChildrenValues();
//    }
//}
