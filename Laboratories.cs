public class Laboratories
{
    public static async Task GetSplits()
    {

        string path = "day7.txt";
        var content = await File.ReadAllLinesAsync(path);
        int c = 0;

        for (int i = 1; i < content.Length; i++)
        {
            foo();
            char[] row = content[i].ToCharArray();
            for (int j = 0; j < row.Length; j++)
            {
                switch (row[j])
                {
                    case '.':
                        if (content[i - 1][j] == 'S' || content[i - 1][j] == '|')
                        {
                            row[j] = '|';
                        }
                        break;


                    case '^':
                        if (content[i - 1][j] == '|')
                        {
                            row[j + 1] = '|';
                            row[j - 1] = '|';
                            c++;
                        }
                        break;

                    default:
                        break;
                }
            }
            content[i] = string.Join("", row);
        }

        Console.WriteLine("Final State:");
        Console.WriteLine(string.Join('\n', content));
        void foo()
        {
            Console.WriteLine("Current State:");
            Console.WriteLine(string.Join('\n', content));
            Console.WriteLine("Current splits {0}", c);
            Console.WriteLine();
        }
    }


}