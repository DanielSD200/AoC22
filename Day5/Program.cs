
using System.Linq;
using System.Text.RegularExpressions;

List<string> input = File.ReadAllText(@"C:\Work\AdventOfCode22\AoC22\Day5\input.txt").Split("\r\n\r\n").ToList();

var crates = input[0].Split("\n")
    .Select(x => x.Chunk(4).Select(x => x[1]))
    .SelectMany(x => x.Select(((crate, cratePostion) => new { crate, cratePostion }))).ToList()
    .Where(x => !char.IsWhiteSpace(x.crate)).Where(x => !int.TryParse(x.crate.ToString(), out int result))
    .Reverse()
    .GroupBy(x => x.cratePostion, x => x.crate)
    .OrderBy(x => x.Key)
    .ToArray();

var commands = input[1].Split("\n")
    .Select(x => Regex.Matches(x, @"\d+"))
    .Select(x => new
    {
        Take =  int.Parse(x[0].ToString()),
        From = int.Parse(x[1].ToString()) -1,
        To = int.Parse(x[2].ToString()) -1
    }).ToList();

var stacks = new IEnumerable<char>[crates.Length];
var stacks2 = new IEnumerable<char>[crates.Length];
crates.CopyTo(stacks, 0);
crates.CopyTo(stacks2, 0);

foreach (var command in commands)
{
    //Console.WriteLine($"Take {command.Take} from {command.From + 1} and move to {command.To + 1}");

    for (int i = 0; i < command.Take; i++)
    {
        var toMove = stacks[command.From].TakeLast(1);
        //var toTake = stacks[command.From].TakeLast(1);
        //Console.WriteLine($"moving {toMove[0].ToString()}");

        stacks[command.To] = stacks[command.To].Concat(toMove).ToArray();
        stacks[command.From] = stacks[command.From].SkipLast(1).ToArray();
    }
}
Console.WriteLine($"Part 1{new string(stacks.Select(s => s.Last()).ToArray())}");

foreach (var command in commands)
{
    var toMove = stacks2[command.From].TakeLast(command.Take);

    stacks2[command.To] = stacks2[command.To].Concat(toMove).ToArray();
    stacks2[command.From] = stacks2[command.From].SkipLast(command.Take).ToArray();

}
Console.WriteLine($"Part 2: {new string(stacks2.Select(s => s.Last()).ToArray())}");


//foreach (string command in commands)
//{
//    var orders = Regex.Matches(command, @"\d+").Select(x => int.Parse(x.Value)).ToList();
//    var stacks = new IEnumerable<char>[crates.Length];

//    crates.CopyTo(stacks, 0);


//    Console.WriteLine($"{command}");
//}


//List<string>[] crates = new List<string>[9];
//crates[0] = new List<string>();
//crates[1] = new List<string>();
//crates[2] = new List<string>();
//crates[3] = new List<string>();
//crates[4] = new List<string>();
//crates[5] = new List<string>();
//crates[6] = new List<string>();
//crates[7] = new List<string>();
//crates[8] = new List<string>();

//(from x in input
// where x.Contains("[")
// select new
// {
//     crate1 = x[1].ToString(),
//     crate2 = x[5].ToString(),
//     crate3 = x[9].ToString(),
//     crate4 = x[13].ToString(),
//     crate5 = x[17].ToString(),
//     crate6 = x[21].ToString(),
//     crate7 = x[25].ToString(),
//     crate8 = x[29].ToString(),
//     crate9 = x[33].ToString()
// }).ToList().ForEach(crate =>
// {
//     crates[1].Add(crate.crate2);
//     crates[2].Add(crate.crate3);
//     crates[3].Add(crate.crate4);
//     crates[4].Add(crate.crate5);
//     crates[5].Add(crate.crate6);
//     crates[6].Add(crate.crate7);
//     crates[7].Add(crate.crate8);
//     crates[8].Add(crate.crate9);
// });

//var inputInstructions = input.Select(x => x).Where(x => !x.Contains("[")).Where(x => x.ToLower().Contains("move")).ToList();

