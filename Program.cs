Binary binary = new Binary()
{
    Name = "Двоичное"
};
Console.Write(binary);

Console.Write("Введите первое число:");
double first = double.Parse(Console.ReadLine()!);
Console.Write("Введите второе число:");
double second = double.Parse(Console.ReadLine()!);
Decimal decimall = new Decimal
{
    Name = "Десятичное",
    First = first,
    Second = second
};
Console.WriteLine(decimall);


abstract class Integer
{
    public string? Name { get; set; }
    public abstract double Add(); 
    public abstract double Subtract();
    public abstract double Multiply();
    public abstract double Divide();

}

public class Decimal : Integer
{
    public double First { get; set; }
    public double Second { get; set; }
    public override double Add() => First + Second;
    public override double Subtract() => First - Second;
    public override double Multiply() => First * Second;
    public override double Divide() => First/Second;
    public override string ToString()
    {
        return $"Сложение:{Add():F2}, Вычитание:{Subtract():F2}, Умножение:{Multiply():F2}, Деление:{Divide():F2}";
    }
}

public class Binary : Integer
{
    public double First { get; set; }
    public double Second { get; set; }
    public override double Add() => First + Second;
    public override double Subtract() => First - Second;
    public override double Multiply() => First * Second;
    public override double Divide() => First / Second;
    public override string ToString()
    {
        return $"Сложение:{Add():F2}, Вычитание:{Subtract():F2}, Умножение:{Multiply():F2}, Деление:{Divide():F2}";
    }
}
