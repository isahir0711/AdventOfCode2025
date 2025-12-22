public class Factory
{
    public static async Task GetButtons()
    {
        string path = "day10.txt";
        string[] lines = await File.ReadAllLinesAsync(path);
        int totalPresses = 0;

        foreach (var l in lines)
        {
            string[] splitted = l.Split(' ');
            string desired = splitted[0];
            Console.WriteLine($"Objective {desired}");
            int indicatorLength = desired.Length - 2;
            int[] targetState = new int[indicatorLength];
            for (int i = 0; i < indicatorLength; i++)
            {
                targetState[i] = desired[i + 1] == '#' ? 1 : 0;
            }
            List<int[]> indicators = [];
            for (int i = 1; i < splitted.Length - 1; i++)
            {
                int[] resIndicator = Enumerable.Repeat(0, indicatorLength).ToArray();
                string onlyValues = splitted[i].Substring(1, splitted[i].Length - 2);
                if (!string.IsNullOrEmpty(onlyValues))
                {
                    string[] values = onlyValues.Split(',');
                    for (int j = 0; j < values.Length; j++)
                    {
                        resIndicator[Convert.ToInt32(values[j])] = 1;
                    }
                }
                indicators.Add(resIndicator);
                Console.WriteLine(string.Concat(resIndicator) + " - " + onlyValues);
            }
            int minPresses = FindMinimumPresses(targetState, indicators, indicatorLength);
            Console.WriteLine($"Minimum presses: {minPresses}");
            Console.WriteLine();
            totalPresses += minPresses;
        }

        Console.WriteLine($"Total minimum button presses: {totalPresses}");

        int FindMinimumPresses(int[] target, List<int[]> buttons, int numLights)
        {
            int numButtons = buttons.Count;

            for (int totalPresses = 0; totalPresses <= numButtons; totalPresses++)
            {
                if (TryAllCombinations(target, buttons, numLights, totalPresses, 0, new List<int>()))
                {
                    return totalPresses;
                }
            }

            return -1;
        }

        bool TryAllCombinations(int[] target, List<int[]> buttons, int numLights, int numPresses, int startIdx, List<int> chosen)
        {
            if (chosen.Count == numPresses)
            {
                int[] state = new int[numLights];
                foreach (int buttonIdx in chosen)
                {
                    for (int i = 0; i < numLights; i++)
                    {
                        state[i] ^= buttons[buttonIdx][i];
                    }
                }
                bool matches = true;
                for (int i = 0; i < numLights; i++)
                {
                    if (state[i] != target[i])
                    {
                        matches = false;
                        break;
                    }
                }

                if (matches)
                {
                    Console.Write("Solution using buttons: ");
                    foreach (int idx in chosen)
                    {
                        Console.Write($"{idx} ");
                    }
                    Console.WriteLine();
                    return true;
                }
                return false;
            }
            for (int i = startIdx; i < buttons.Count; i++)
            {
                chosen.Add(i);
                if (TryAllCombinations(target, buttons, numLights, numPresses, i, chosen))
                {
                    return true;
                }
                chosen.RemoveAt(chosen.Count - 1);
            }

            return false;
        }

    }
}
