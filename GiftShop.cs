
public class GiftShop
{
    public async static Task GetInvalidIDs()
    {
        string input = await File.ReadAllTextAsync("day2.txt");
        List<string> ranges = input.Split(',').ToList();
        long sum = 0;

        foreach (var range in ranges)
        {
            string start = range.Split('-')[0];
            string end = range.Split('-')[1];
            for (long i = long.Parse(start); i <= long.Parse(end); i++)
            {
                string s = Convert.ToString(i);
                int h = s.Length / 2;
                if (s[..h] == s[h..])
                {
                    sum += i;
                }
            }
        }
        Console.WriteLine(sum);
    }

    public static async Task GetInvalidIDsPart2()
    {
        string input = await File.ReadAllTextAsync("day2.txt");
        long sum = 0;
        List<string> ranges = input.Split(',').ToList();
        foreach (var item in ranges)
        {
            string start = item.Split('-')[0];
            string end = item.Split('-')[1];

            for (long k = long.Parse(start); k <= long.Parse(end); k++)
            {
                string val = Convert.ToString(k);
                for (int i = 1; i <= val.Length / 2; i++)
                {
                    string sbstr = val[..i];
                    int times = val.Length / sbstr.Length;
                    string cons = String.Concat(Enumerable.Repeat(sbstr, times));
                    if (cons == val)
                    {
                        Console.WriteLine(val);
                        sum += k;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(sum);

    }
}