public class Reactor
{
    public static async Task GetPaths()
    {
        string path = "day11.txt";
        string[] input = await File.ReadAllLinesAsync(path);
        var graph = new Graph<string>();

        foreach (var line in input)
        {
            string[] arr = line.Split(' ');
            string origin = arr[0];
            origin = origin.Substring(0, origin.Length - 1);
            for (int i = 1; i < arr.Length; i++)
            {
                graph.AddEdge(origin, arr[i]);
            }

        }
        var paths = graph.GetPaths("you", "out");
        Console.WriteLine(paths.Count);
    }
    public class Graph<T>
    {
        private Dictionary<T, List<T>> Neighbours;

        public Graph()
        {
            Neighbours = new Dictionary<T, List<T>>();
        }

        public void AddNode(T node)
        {
            if (!Neighbours.ContainsKey(node))
            {
                Neighbours[node] = new List<T>();
            }
        }

        public void AddEdge(T originNode, T destinationNode)
        {
            if (!Neighbours.ContainsKey(originNode))
                AddNode(originNode);

            if (!Neighbours.ContainsKey(destinationNode))
                AddNode(destinationNode);

            Neighbours[originNode].Add(destinationNode);
        }

        public List<T> GetNeighbours(T node)
        {
            return Neighbours.ContainsKey(node)
                ? Neighbours[node]
                : new List<T>();
        }

        public List<List<T>> GetPaths(T start, T end)
        {
            var paths = new List<List<T>>();
            var currentPath = new List<T>();
            var visited = new HashSet<T>();

            DFS(start, end, visited, currentPath, paths);

            return paths;
        }

        private void DFS(T current, T end, HashSet<T> visited,
                         List<T> currentPath, List<List<T>> paths)
        {
            visited.Add(current);
            currentPath.Add(current);

            if (current.Equals(end))
            {
                paths.Add(new List<T>(currentPath));
            }
            else
            {
                foreach (var neighbour in GetNeighbours(current))
                {
                    if (!visited.Contains(neighbour))
                    {
                        DFS(neighbour, end, visited, currentPath, paths);
                    }
                }
            }

            currentPath.RemoveAt(currentPath.Count - 1);
            visited.Remove(current);
        }

    }
}