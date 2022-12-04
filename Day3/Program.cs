// See https://aka.ms/new-console-template for more information
List<string> backpackInput = File.ReadAllLines(@"C:\Work\AdventOfCode22\AoC22\Day3\input.txt").ToList();

string lowerCasePostionString = "abcdefghijklmnopqrstuvwxyz";
string upperCasePostionString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

List<int> result = new List<int>();
List<int> result2 = new List<int>();

foreach (string items in backpackInput)
{
    var length = items.Length;

    var compartmentOne = items.Substring(0, length/2);
    var compartmentTwo = items.Substring((length/2));

    var intersect = compartmentOne.Intersect(compartmentTwo).ToList();

    intersect.ForEach(x =>
    {
        if (lowerCasePostionString.Contains(x))
        {
            var position = lowerCasePostionString.IndexOf(x) + 1;
            //Console.WriteLine($"{x} was found in lower case string at position {position}");
            result.Add(position);
        }
        else if (upperCasePostionString.Contains(x))
        {
            var position = upperCasePostionString.IndexOf(x) + 27;
            //Console.WriteLine($"{x} was found in upper case string at position {position}");
            result.Add(position);
        }
    });
}


//result.ForEach(x => Console.WriteLine($"{x}"));
Console.WriteLine($"Part 1: Total result is: {result.Sum()}");

for (int i = 0; i < backpackInput.Count; i+=3)
{
    string elfOne = backpackInput[i];
    string elfTwo = backpackInput[i+1];
    string elfThree = backpackInput[i+2];

    var intersect = elfOne.Intersect(elfTwo).ToList();
    var intersectTwo = elfOne.Intersect(elfThree).ToList();

    var finalIntersect = intersect.Intersect(intersectTwo).ToList();

    finalIntersect.ForEach(x =>
    {
        if (lowerCasePostionString.Contains(x))
        {
            var position = lowerCasePostionString.IndexOf(x) + 1;
            Console.WriteLine($"{x} was found in lower case string at position {position}");
            result2.Add(position);
        }
        else if (upperCasePostionString.Contains(x))
        {
            var position = upperCasePostionString.IndexOf(x) + 27;
            Console.WriteLine($"{x} was found in upper case string at position {position}");
            result2.Add(position);
        }
    });
}

Console.WriteLine($"Part 2: Total result is: {result2.Sum()}");