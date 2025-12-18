public class MovieTheater
{
    public static async Task GetLargestRectangle()
    {
        string path = "day9.txt";
        string[] lines = await File.ReadAllLinesAsync(path);

        long[,] coords = new long[lines.Length, 2];

        for (long i = 0; i < coords.GetLength(0); i++)
        {
            string[] val = lines[i].Split(',');
            long x = Convert.ToInt64(val[0]);
            long y = Convert.ToInt64(val[1]);
            coords[i, 0] = x;
            coords[i, 1] = y;
        }

        long maxArea = 0;

        for (long i = 0; i < coords.GetLength(0); i++)
        {
            for (long j = 0; j < coords.GetLength(0); j++)
            {
                long x1 = coords[i, 0];
                long x2 = coords[j, 0];
                long y1 = coords[i, 1];
                long y2 = coords[j, 1];
                long dx = Math.Abs(x2 - x1) + 1;
                long dy = Math.Abs(y2 - y1) + 1;
                long area = dx * dy;
                Console.WriteLine($"{x1} {y1} - {x2} {y2}={area}");
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

        }

        Console.WriteLine(maxArea);
    }
}