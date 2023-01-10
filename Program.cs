/*
Задача: Заданы 2 массива: info и data. В массиве info хранятся двоичные представления нескольких чисел (без разделителя). В массиве data хранится информация о количестве бит, которые занимают числа из массива info. Напишите программу, которая составит массив десятичных представлений чисел массива data с учётом информации из массива info.

Комментарий: первое число занимает 2 бита (01 -> 1); второе число занимает 3 бита (111 -> 7); третье число занимает 3 бита (000 -> 0; четвёртое число занимает 1 бит (1 -> 1)

Пример:

входные данные:
data = {0, 1, 1, 1, 1, 0, 0, 0, 1 }
info = {2, 3, 3, 1 }

выходные данные:
1, 7, 0, 1
*/

Random rnd = new Random();

// Задает бинарный массив длиной, которую ввел пользователь
Console.Write("Enter array length ==> ");
int length = Int32.Parse(Console.ReadLine());
int[] info = new int[length];
Console.Write("info = ");
for (int i = 0; i < length; i++)
{
    info[i] = rnd.Next(2);
    Console.Write(info[i] + " ");
}
Console.WriteLine();
Console.WriteLine();

// Определяет сколько чисел указано в бинарном массиве и сколько бит каждое число весит

int number = 0;
int[] Clone = new int[length - 1];
int lengthData = 0;
int q = 0;
while (q != length)
{
    Console.Write("Enter how many bits occupies 1 number (3 bits; 2 bits, 1 bit) ==> ");
    number = Int32.Parse(Console.ReadLine());
    if (number != 1 && number != 2 && number != 3)
    {
        Console.WriteLine("You must enter 3, 2 or 1. You entered an incorrect answer. A random number will be chosen for you");
        number = rnd.Next(1, 4);
    }
    if (q + number >= length)
    {
        number = length - q;
        Console.WriteLine("Attention! Remaining size ==> " + number + "bit");
    }
    Clone[lengthData] = number;
    lengthData++;
    q += number;
}

Console.WriteLine();

// Создает массив веса бинарных чисел


int[] data = new int[lengthData];
Console.Write("data = ");

for (int i = 0; i < (lengthData); i++)
{
    data[i] = Clone[i];
    Console.Write(data[i] + " ");
}

Console.WriteLine();
Console.WriteLine();

int p = 0;
for (int i = 0; i < lengthData; i++)
{   
    double binaryNumber = 0;
    int degree = 0;
    for (int u = 0; u < data[i]; u++)
    {
        degree = (data[i] - 1) - u;
        binaryNumber += (double)info[p]*Math.Pow(2, (degree));
        p++;
    }
    Console.WriteLine((i+1) + " number ==> " + binaryNumber + " | ");
}

