public class Cafeteria
{
    public static async Task GetSpoiledCount()
    {
        string path = "day5.txt";
        var content = await File.ReadAllLinesAsync(path);

        int ranges = 0;

        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] == "")
            {
                break;
            }
            else
            {
                ranges++;
            }
        }

        int accum = 0;

        for (int i = ranges + 1; i < content.Length; i++)
        {
            long id = Convert.ToInt64(content[i]);
            bool isValid = false;
            for (int j = 0; j < ranges; j++)
            {
                var spl = content[j].Split('-');
                long b = Convert.ToInt64(spl[0]);
                long t = Convert.ToInt64(spl[1]);
                if (id >= b && id <= t)
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid)
            {
                accum++;
                Console.WriteLine("Valid one: " + id);
            }
        }

        Console.WriteLine("total: " + accum);
    }

    // public static async Task GetFresh()
    // {
    //     //:(

    // }
}