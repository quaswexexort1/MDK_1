public class Program
{
   public static void Main(string[] args)
    {
        Decimal decimal1 = new Decimal(new int[] { 123 });
        Decimal decimal2 = new Decimal(new int[] { 456 });

        Console.WriteLine("Десятичное:");

        Console.Write($"Сложение: первое + второе:");
        decimal1.Add(decimal2).Print();
        Console.Write($"Вычитание: второе - первое:");
        decimal2.Subtract(decimal1).Print();
        Console.Write($"Умножение: первое * второе:");
        decimal1.Multiply(decimal2).Print();
        Console.Write($"Деление: второе / первое:");
        decimal2.Divide(decimal1).Print();

        Console.WriteLine();


        Binary binary1 = new Binary(new int[] { 1, 0, 1, 1 });
        Binary binary2 = new Binary(new int[] { 1, 1, 0, 1 });

        Console.WriteLine("Двоичное:");

        Console.Write($"Сложение: первое + второе:");
        binary1.Add(binary2).Print();
        Console.Write($"Вычитание: второе - первое:");
        binary2.Subtract(binary1).Print();
        Console.Write($"Умножение: первое * второе:");
        binary1.Multiply(binary2).Print();
        Console.Write($"Деление: второе / первое:");
        binary2.Divide(binary1).Print();

        Binary divBinary = (Binary)binary1.Divide(binary2);
        divBinary.Print();
    }
}



public abstract class Integer
{
    protected int[] digits;
    public Integer(int[] d) => digits = d;
    public abstract Integer Add(Integer other);
    public abstract Integer Subtract(Integer other);
    public abstract Integer Multiply(Integer other);
    public abstract Integer Divide(Integer other);

    public abstract void Print();
}
public class Decimal : Integer
{
    public Decimal(int[] digits) : base(digits) { }
    public override Integer Add(Integer other)
    {
        Decimal o = (Decimal)other;
        int len = Math.Max(digits.Length, o.digits.Length);
        int[] res = new int[len + 1];
        int carry = 0;
        for (int i = 0; i < len; i++)
        {
            int d1 = i < digits.Length ? digits[digits.Length - 1 - i] : 0;
            int d2 = i < o.digits.Length ? o.digits[o.digits.Length - 1 - i] : 0;
            int sum = d1 + d2 + carry;
            res[len - i] = sum % 10;
            carry = sum / 10;
        }
        if (carry > 0) res[0] = carry;
        return new Decimal(res.SkipWhile(x => x == 0).ToArray());
    }

    //ВЫЧИТАНИЕ

    public override Integer Subtract(Integer other)
    {
        Decimal o = (Decimal)other;
        int len = Math.Max(digits.Length, o.digits.Length);
        int[] res = new int[len];
        int borrow = 0;

        for (int i = 0; i < len; i++)
        {
            int d1 = i < digits.Length ? digits[digits.Length - 1 - i] : 0;
            int d2 = i < o.digits.Length ? o.digits[o.digits.Length - 1 - i] : 0;
            int diff = d1 - d2 - borrow;
            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            res[len - 1 - i] = diff;
        }
        return new Decimal(res.SkipWhile(x => x == 0).ToArray());
    }

    //УМНОЖЕНИЕ

    public override Integer Multiply(Integer other)
    {
        Decimal o = (Decimal)other;
        int len1 = digits.Length;
        int len2 = o.digits.Length;
        int[] result = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--)
        {
            int carry = 0;
            for (int j = len2 - 1; j >= 0; j--)
            {
                int product = digits[i] * o.digits[j] + result[i + j + 1] + carry;
                result[i + j + 1] = product % 10;
                carry = product / 10;
            }
            result[i] += carry;
        }

        return new Decimal(result.SkipWhile(x => x == 0).ToArray());
    }

    //ДЕЛЕНИЕ

    public override Integer Divide(Integer other)
    {
        Decimal o = (Decimal)other;
    }

    public override void Print() => Console.WriteLine(string.Join("", digits.Reverse()));
}

//ДВОИЧНОЕ

public class Binary : Integer
{
    public Binary(int[] digits) : base(digits) { }
    public override Integer Add(Integer other)
        {
        Binary o = (Binary)other;
        int len = Math.Max(digits.Length, o.digits.Length);
        int[] res = new int[len + 1];
        int carry = 0;
        for (int i = 0; i < len; i++)
        {
            int d1 = i < digits.Length ? digits[digits.Length - 1 - i] : 0;
            int d2 = i < o.digits.Length ? o.digits[o.digits.Length - 1 - i] : 0;
            int sum = d1 + d2 + carry;
            res[len - i] = sum % 2;
            carry = sum / 2;
        }
        if (carry > 0) res[0] = carry;
        return new Binary(res.SkipWhile(x => x == 0).ToArray());
    }

    //ВЫЧИТАНИЕ

    public override Integer Subtract(Integer other)
    {
        Binary o = (Binary)other;

        int len = Math.Max(digits.Length, o.digits.Length);
        int[] res = new int[len];
        int borrow = 0;

        for (int i = 0; i < len; i++)
        {
            int d1 = i < digits.Length ? digits[digits.Length - 1 - i] : 0;
            int d2 = i < o.digits.Length ? o.digits[o.digits.Length - 1 - i] : 0;
            int diff = d1 - d2 - borrow;
            if (diff < 0)
            {
                diff += 2;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            res[len - 1 - i] = diff;
        }

        return new Binary(res.SkipWhile(x => x == 0).ToArray());
    }

    //УМНОЖЕНИЕ

    public override Integer Multiply(Integer other)
    {
        Binary o = (Binary)other;

        int[] result = new int[digits.Length + o.digits.Length];

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] == 1)
            {
                int carry = 0;
                for (int j = o.digits.Length - 1; j >= 0; j--)
                {
                    int sum = o.digits[j] + result[i + j + 1] + carry;
                    result[i + j + 1] = sum % 2;
                    carry = sum / 2;
                }
                result[i] += carry;

            }
        }
        return new Binary(result.SkipWhile(x => x == 0).ToArray());
    }

    //ДЕЛЕНИЕ

    public override Integer Divide(Integer other)
    {
        Binary o = (Binary)other;

    }

    public override void Print() => Console.WriteLine(string.Join("", digits.Reverse()));
}

