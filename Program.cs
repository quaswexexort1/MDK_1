Console.Write("Введите первое число для двоичного:");
double firstBinary = double.Parse(Console.ReadLine()!);
Console.Write("Введите второе число для двоичного:");
double secondBinary = double.Parse(Console.ReadLine()!);

Binary binary = new Binary()
{
    Name = "Двоичное",
    FirstBinary = firstBinary,
    SecondBinary = secondBinary
};
Console.WriteLine(binary);

Console.Write("Введите первое число для десятичного:");
double firstDecimal = double.Parse(Console.ReadLine()!);
Console.Write("Введите второе число для десятичного:");
double secondDecimal = double.Parse(Console.ReadLine()!);


Decimal decimall = new Decimal
{
    Name = "Десятичное",
    FirstDecimal = firstDecimal,
    SecondDecimal = secondDecimal
};
Console.WriteLine(decimall);


public abstract class Integer
{
    public string? Name { get; set; }
    public abstract double Add();
    public abstract double Subtract();
    public abstract double Multiply();
    public abstract double Divide();

}

public class Decimal : Integer
{
    public double FirstDecimal { get; set; }
    public double SecondDecimal { get; set; }
    public override double Add() => FirstDecimal + SecondDecimal;

    public override double Subtract() => FirstDecimal - SecondDecimal;
    public override double Multiply() => FirstDecimal * SecondDecimal;
    public override double Divide() => FirstDecimal / SecondDecimal;
    public override string ToString()
    {
        return $"Сложение:{Add():F2}, Вычитание:{Subtract():F2}, Умножение:{Multiply():F2}, Деление:{Divide():F2}";
    }
}

public class Binary : Integer
{
    public double FirstBinary { get; set; }
    public double SecondBinary { get; set; }
    public override double Add() => FirstBinary + SecondBinary;
    public override double Subtract() => FirstBinary - SecondBinary;
    public override double Multiply() => FirstBinary * SecondBinary;
    public override double Divide() => FirstBinary / SecondBinary;
    public override string ToString()
    {
        return $"Сложение:{Add():F2}, Вычитание:{Subtract():F2}, Умножение:{Multiply():F2}, Деление:{Divide():F2}";
    }
}

