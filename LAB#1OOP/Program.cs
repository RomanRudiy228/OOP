//1 Приклад 18-В
Console.WriteLine("1) x= ");
string inputx = Console.ReadLine();
double x = Convert.ToDouble(inputx);

Console.WriteLine("z= ");
string inputz = Console.ReadLine();
double z = Convert.ToDouble(inputz);

double y;
y = (Math.Abs(Math.Pow(x, 3) - Math.Pow(z, 3))) / (Math.Sqrt((x*x) - 9));
Console.WriteLine("y = " + y);

//2 Дано натуральні числа n, b1, b2, ..., bn. Знайти ті члени bk послідовності b1, b2, ..., bn, що при діленні на 7 дають залишок 1, 2 або 5
Console.WriteLine("2) Vvedit' kil'kist' chisel (n):");
int n = int.Parse(Console.ReadLine());

int[] poslidov = new int[n];

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Vvedit' {i + 1}-е chislo:");
    poslidov[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Chisla poslidovnosti, yaki dayut' zalishok 1, 2 abo 5 pri dilenni na 7:");

foreach (int num in poslidov)
{
    if (num % 7 == 1 || num % 7 == 2 || num % 7 == 5)
    {
        Console.WriteLine(num);
    }
}

//3 Дано натуральне число n.З'ясуйте чи знаходиться серед чисел n, n+1,...,2n близнюки - прості числа, різниця яких дорівнює 2.
//(Визначити функцію, що дозволяє розпізнавати прості числа.) 

    Console.Write("3) Vvedit' natural'ne chislo n: ");
    int N = int.Parse(Console.ReadLine());

    Console.WriteLine($"Pohozhi prosti chisla u diapazoni vid {N} do {2 * N}:");
    findtwinprost(N, 2 * N);

    Console.ReadKey();

static bool isproste(int number)
{
    if (number <= 1)
        return false;
    if (number <= 3)
        return true;

    if (number % 2 == 0 || number % 3 == 0)
        return false;

    for (int i = 5; i * i <= number; i += 6)
    {
        if (number % i == 0 || number % (i + 2) == 0)
            return false;
    }

    return true;
}

static void findtwinprost(int start, int end)
{
    for (int i = start; i <= end - 2; i++)
    {
        if (isproste(i) && isproste(i + 2))
        {
            Console.WriteLine($"{i} i {i + 2}");
        }
    }
}