using System.Dynamic;

public class PrintingDepartment
{
    public static async Task GetAccessibleRolls()
    {
        string[] input = await File.ReadAllLinesAsync("day4.txt");
        string[,] places = CreateMap(input);
        Console.WriteLine(TraverseMap(places));
    }

    public static async Task RemoveManyAsPossible()
    {
        string[] input = await File.ReadAllLinesAsync("day4.txt");
        string[,] places = CreateMap(input);
        int sum = 0;
        int removed = 0;
        do
        {
            removed = TraverseMap2(places);
            sum += removed;
        }
        while (removed > 0);
        Console.WriteLine(sum);

    }

    static int TraverseMap2(string[,] m)
    {
        Console.WriteLine();
        Console.WriteLine("Current map");
        PrintMap((string[,])m);
        int accum = 0;
        string[,] copy = new string[m.GetLength(0), m.GetLength(1)];
        Array.Copy(m, 0, m, 0, m.Length);

        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                // Console.Write(m[i, j]);
                if (m[i, j] != "@")
                {
                    continue;
                }
                if (IsValid(m, i, j))
                {
                    // Console.WriteLine($"Accesible roll {i}, {j}");
                    m[i, j] = ".";
                    accum++;
                }
            }
        }

        return accum;
    }

    static int TraverseMap(string[,] m)
    {
        int accum = 0;
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                // Console.Write(m[i, j]);
                if (m[i, j] != "@")
                {
                    continue;
                }
                if (IsValid(m, i, j))
                {
                    Console.WriteLine($"Accesible roll {i}, {j}");
                    accum++;
                }
            }
        }
        return accum;
    }
    static bool IsValid(string[,] map, int i, int j)
    {

        int c = 0;
        int n = map.GetLength(0);
        int m = map.GetLength(1);

        int[,] dirs = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };

        for (int k = 0; k < dirs.GetLength(0); k++)
        {
            int x = i + dirs[k, 0];
            int y = j + dirs[k, 1];
            if (x < 0 || y < 0 || x >= n || y >= m)
                continue;

            // Console.WriteLine($"Checking pos [{x} {y}], char is {map[x, y]}");

            if (map[x, y] == "@")
            {
                c++;
            }
        }

        return c < 4;

    }
    static string[,] CreateMap(string[] input)
    {
        string[,] map = new string[input.Length, input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            char[] sep = input[i].ToArray();
            for (int j = 0; j < sep.Length; j++)
            {
                map[i, j] = sep[j].ToString();
            }
        }

        return map;

    }

    static void PrintMap(string[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Console.Write(m[i, j]);
            }
            Console.WriteLine();
        }
    }
}