public static class Lobby
{
    public async static Task GetJolts()
    {
        string[] lines = await File.ReadAllLinesAsync("day3.txt");
        int max = 0;
        int sum = 0;

        foreach (var dude in lines)
        {
            max = 0;
            for (int i = 0; i < dude.Length; i++)
            {
                for (int j = i + 1; j < dude.Length; j++)
                {
                    string un = dude[i] + "" + dude[j];
                    int check = Convert.ToInt16(un);
                    if (check > max)
                    {
                        max = check;
                    }
                }
            }
            sum += max;
            Console.WriteLine(max);
        }

        Console.WriteLine(sum);

    }

    public async static Task GetJoltsPart2()
    {
        string[] lines = await File.ReadAllLinesAsync("day3.txt");
        int max = 0;
        int sum = 0;

        foreach (var dude in lines)
        {
            max = 0;
            for (int i = 0; i < dude.Length; i++)
            {
                for (int j = i + 1; j < dude.Length; j++)
                {
                    string un = dude[i] + "" + dude[j];
                    int check = Convert.ToInt16(un);
                    if (check > max)
                    {
                        max = check;
                    }
                }
            }
            sum += max;
            Console.WriteLine(max);
        }

        Console.WriteLine(sum);

    }
}