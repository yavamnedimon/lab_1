using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы списка через пробел:");
        string input = Console.ReadLine();

        List<int> numbers = input.Split(' ').Select(int.Parse).ToList();

        Console.Write("Введите значение n: ");
        int n = int.Parse(Console.ReadLine());

        List<int> result = SelectElementsRepeatedMoreThanNTimes(numbers, n);

        Console.WriteLine("Элементы, встречающиеся более " + n + " раз:");
        result.ForEach(Console.WriteLine);
    }

    static List<T> SelectElementsRepeatedMoreThanNTimes<T>(List<T> list, int n)
    {
        Dictionary<T, int> counts = list
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());

        List<T> result = list
            .Where(item => counts.ContainsKey(item) && counts[item] > n)
            .Distinct()
            .ToList();

        return result;
    }
}