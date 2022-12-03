using System.Collections;
using System.Security.Cryptography.X509Certificates;

List<string> rpsInput = File.ReadAllLines(@"C:\Work\AdventOfCode22\AoC22\Day2\input.txt").ToList().Select(x => x.Replace(" ", string.Empty)).ToList();

var results = rpsInput.Select(x => new
{
    result = x.Replace(" ", string.Empty).ToString()
}).ToList();



// A == Rock, B == Paper, C == Scissors
// X == Rock == 1, Y == Paper == 2, Z == Scissors == 3

// Win == 6, Draw == 3, Loss = 0


//Combinations
// AX = draw == 4
// AY = win == 8
// AZ = loss == 3
// BX = loss = 1
// BY = draw = 5
// BZ = win = 9
// CX = win = 7
// CY = loss = 2
// CZ = draw = 6

List<int> resultScores = new List<int>();
foreach (string result in rpsInput)
{
    switch (result)
    {
        case "AX":
            resultScores.Add(4);
            break;

        case "AY":
            resultScores.Add(8);
            break;

        case "AZ":
            resultScores.Add(3);
            break;

        case "BX":
            resultScores.Add(1);
            break;

        case "BY":
            resultScores.Add(5);
            break;

        case "BZ":
            resultScores.Add(9);
            break;

        case "CX":
            resultScores.Add(7);
            break;

        case "CY":
            resultScores.Add(2);
            break;

        case "CZ":
            resultScores.Add(6);
            break;
    }     
}

Console.WriteLine(resultScores.Sum());

List<int> resultScores2 = new List<int>();
foreach (string result in rpsInput)
{
    if (result.EndsWith("X")) // Lose
    {
        if (result.StartsWith("A"))
        {
            resultScores2.Add(3);
        }
        else if ( result.StartsWith("B"))
        {
            resultScores2.Add(1);
        }
        else
        {
            resultScores2.Add(2);
        }
    }
    else if (result.EndsWith("Y")) // Draw
    {
        if (result.StartsWith("A"))
        {
            resultScores2.Add(4);
        }
        else if (result.StartsWith("B"))
        {
            resultScores2.Add(5);
        }
        else
        {
            resultScores2.Add(6);
        }
    }
    else // Win
    {
        if (result.StartsWith("A"))
        {
            resultScores2.Add(8);
        }
        else if (result.StartsWith("B"))
        {
            resultScores2.Add(9);
        }
        else
        {
            resultScores2.Add(7);
        }
    }
}

Console.WriteLine(resultScores2.Sum());