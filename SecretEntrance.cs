public class SecretEntrance
{
    public static async Task GetPassword()
    {
        string path = "day1.txt";

        string[] input = await File.ReadAllLinesAsync(path);
        int dial = 50;
        int password = 0;

        Console.WriteLine("started at 50");
        foreach (string line in input)
        {
            Console.WriteLine("current dial:" + dial + " rotation " + line);
            char rotation = line[0];
            int value = Convert.ToInt32(line[1..]);

            if (rotation == 'L')
            {
                for (int i = 0; i < value; i++)
                {
                    dial -= 1;
                    if (dial < 0)
                    {
                        dial = 99;
                    }
                    if (dial == 0)
                    {
                        password++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    dial += 1;
                    if (dial > 99)
                    {
                        dial = 0;
                    }
                    if (dial == 0)
                    {
                        password++;
                    }
                }

            }

        }
        Console.WriteLine(password);
    }
}
