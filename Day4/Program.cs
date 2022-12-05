
//List<string> input = File.ReadAllLines(@"C:\Work\AdventOfCode22\AoC22\Day4\input.txt").ToList();

//var cleaningAreas =
//    from x in input
//    select new
//    {
//        cleaningAreaOne = x.Split(',')[0].Split('-')?.Select(Int32.Parse)?.ToList(),
//        cleaningAreaTwo = x.Split(',')[1].Split('-')?.Select(Int32.Parse)?.ToList(),
//    };

//var fullOverlaps =
//    (from x in cleaningAreas
//     where x.cleaningAreaOne[0] >= x.cleaningAreaTwo[0] && x.cleaningAreaOne[1] <= x.cleaningAreaTwo[1] ||
//     x.cleaningAreaTwo[0] >= x.cleaningAreaOne[0] && x.cleaningAreaTwo[1] <= x.cleaningAreaOne[1]
//     select x).ToList();

//Console.WriteLine($"Part 1: {fullOverlaps.Count()}");

//var partialOverlaps =
//    (from x in cleaningAreas
//     where (x.cleaningAreaOne[0] >= x.cleaningAreaTwo[0] && x.cleaningAreaOne[0] <= x.cleaningAreaTwo[1]) ||
//     (x.cleaningAreaTwo[0] >= x.cleaningAreaOne[0] && x.cleaningAreaTwo[1] <= x.cleaningAreaOne[1])
    
//     select x).ToList();

//partialOverlaps.ForEach(x =>
//    Console.WriteLine($"{x.cleaningAreaOne[0]}-{x.cleaningAreaOne[1]} , {x.cleaningAreaTwo[0]}-{x.cleaningAreaTwo[1]}")
//);

//Console.WriteLine($"Part 2: {partialOverlaps.Count()}");

string input2 = File.ReadAllText(@"C:\Work\AdventOfCode22\AoC22\Day4\input.txt");

Console.WriteLine(SolvePart1(input2));
Console.WriteLine(SolvePart2(input2));

 string SolvePart1(string input) =>
    Parse(input)
        .Count(t =>
            ContainsRange(t.left, t.right) ||
            ContainsRange(t.right, t.left))
        .ToString();

 string SolvePart2(string input) =>
    Parse(input)
        .Count(t =>
            OverlapsWith(t.left, t.right) ||
            OverlapsWith(t.right, t.left))
        .ToString();

 static IEnumerable<((int, int) left, (int, int) right)> Parse(string input) =>
    input
        .Split("\n")
        .Select(line => line.Split(','))
        .Select(ranges => (
            (RangeStart(ranges[0]), RangeEnd(ranges[0])),
            (RangeStart(ranges[1]), RangeEnd(ranges[1]))
        ));

 bool ContainsRange((int, int) lhs, (int, int) rhs) =>
    rhs.Item1 >= lhs.Item1 && rhs.Item2 <= lhs.Item2;

 bool OverlapsWith((int, int) lhs, (int, int) rhs) =>
    rhs.Item1 >= lhs.Item1 && rhs.Item1 <= lhs.Item2;

 static int RangeStart(string input) => int.Parse(input.Substring(0, input.IndexOf('-')));
 static int RangeEnd(string input) => int.Parse(input.Substring(input.IndexOf('-') + 1));