using System.Text.RegularExpressions;
public class TrashCompactor
{
    public static async Task Part1()
    {

        string path = "day6.txt";
        var content = await File.ReadAllLinesAsync(path);

        // content = content.Reverse().ToArray();

        string regex = "\\d+";
        var rows = Regex.Matches(content[0], regex).Count();
        Console.WriteLine("cols: {0}", rows);
        long[] res = new long[rows];
        var op = Regex.Matches(content[^1], "\\S+");


        for (int i = 0; i < rows; i++)
        {
            if (op[i].ToString() == "*")
            {
                res[i] = 1;
            }
        }

        for (int i = 0; i < content.Length - 1; i++)
        {
            var row = Regex.Matches(content[i], regex);

            for (int j = 0; j < rows; j++)
            {
                if (op[j].ToString() == "+")
                {
                    res[j] += Convert.ToInt16(row[j].ToString());
                }
                else
                {
                    res[j] *= Convert.ToInt16(row[j].ToString());
                }

                Console.Write($" {row[j]} ");

            }
            Console.WriteLine();
        }

        long sum = 0;

        Console.WriteLine("///////////////////Results/////////////////");
        for (int i = 0; i < rows; i++)
        {
            sum += res[i];
            Console.WriteLine(res[i]);
        }

        Console.WriteLine("/////////////SUM////////////////\n" + sum);
    }
}