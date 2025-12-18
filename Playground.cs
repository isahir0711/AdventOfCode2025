public class Playground
{
    public static async Task LargestCircuits()
    {
        string path = "day8.txt";
        string[] lines = await File.ReadAllLinesAsync(path);

        List<JBox> boxes = [];
        List<Connections> distances = [];
        List<Circuits> circuits = [];

        foreach (var line in lines)
        {
            string[] t = line.Split(',');
            boxes.Add(new JBox(Convert.ToInt32(t[0]), Convert.ToInt32(t[1]), Convert.ToInt32(t[2])));
        }


        for (int i = 0; i < boxes.Count; i++)
        {
            for (int j = i + 1; j < boxes.Count; j++)
            {
                double dx = boxes[i].X - boxes[j].X;
                double dy = boxes[i].Y - boxes[j].Y;
                double dz = boxes[i].Z - boxes[j].Z;
                double d = dx * dx + dy * dy + dz * dz;
                var con = new Connections
                {
                    Boxes = boxes[i].ToString() + "-" + boxes[j],
                    Distance = d,
                    Box1 = boxes[i],
                    Box2 = boxes[j],
                };
                distances.Add(con);
            }
        }

        distances = distances.OrderBy(x => x.Distance).ToList();

        int yo = 0;
        foreach (var item in distances)
        {
            if (yo >= 10)
            {
                break;
            }
            yo++;
            if (checkIftwo(item.Box1!, item.Box2!, circuits))
            {
                continue;
            }
            addOrMergeCircuits(item.Box1!, item.Box2!, circuits);
        }

        // circuits = circuits.OrderBy(x => x.Boxes.Count).ToList();

        foreach (var item in circuits)
        {
            Console.WriteLine(item.Boxes.Count);
            foreach (var b in item.Boxes)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("//////");
        }

        void addOrMergeCircuits(JBox box1, JBox box2, List<Circuits> cr)
        {
            Circuits? circuit1 = null;
            Circuits? circuit2 = null;

            foreach (var c in cr)
            {
                if (c.Boxes.Contains(box1))
                    circuit1 = c;
                if (c.Boxes.Contains(box2))
                    circuit2 = c;
            }

            if (circuit1 != null && circuit2 != null && circuit1 != circuit2)
            {
                circuit1.Boxes.AddRange(circuit2.Boxes);
                cr.Remove(circuit2);
            }
            else if (circuit1 != null)
            {
                circuit1.Boxes.Add(box2);
            }
            else if (circuit2 != null)
            {
                circuit2.Boxes.Add(box1);
            }
            else
            {
                var c = new Circuits();
                c.Boxes.Add(box1);
                c.Boxes.Add(box2);
                cr.Add(c);
            }
        }

        bool checkIftwo(JBox jBox1, JBox jBox2, List<Circuits> cr)
        {
            foreach (var c in cr)
            {
                if (c.Boxes.Contains(jBox1) && c.Boxes.Contains(jBox2))
                {
                    return true;
                }
            }

            return false;
        }
    }

}
class Circuits
{
    public List<JBox> Boxes { get; set; } = [];
}

class Connections
{
    public JBox? Box1 { get; set; }
    public JBox? Box2 { get; set; }
    public string Boxes { get; set; } = string.Empty;
    public double Distance { get; set; }
}

class JBox
{
    public long X { get; }

    public long Z { get; }

    public long Y { get; }

    public JBox(long x, long y, long z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"{X},{Y},{Z}";
    }
}