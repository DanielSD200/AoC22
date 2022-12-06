// See https://aka.ms/new-console-template for more information
var input = File.ReadAllText(@"C:\Work\AdventOfCode22\AoC22\Day6\input.txt");

int part1MarkerLength = 4;
int part2MarkerLength = 14;

for (int i = 0; i < input.Length -1; i++)
{
    string markerCheck = input.Substring(i, part2MarkerLength);

    if (DuplicateCheck(markerCheck))
    {
        continue;
    }
    else
    {
        Console.WriteLine($"{markerCheck} at position {i + part2MarkerLength}");
        break;
    }
}

static bool DuplicateCheck(string input)
{
    var set = new HashSet<char>();
    return input.Any(x => !set.Add(x));
}