
var calorieInput = File.ReadAllText(@"input.txt");
string[] elvesCalories = calorieInput.Split("\r\n\r\n", System.StringSplitOptions.RemoveEmptyEntries);

List<int> calorieTotals = new List<int>();

for (int i = 0; i < elvesCalories.Count(); i++)
{
    var elfCalorieTotal = (Array.ConvertAll(elvesCalories[i].Split("\r\n"), s => Int32.Parse(s))).ToList().Sum();

    calorieTotals.Add(elfCalorieTotal);
}

var highestCalories = calorieTotals.OrderDescending().FirstOrDefault();

var topThreeCalories = calorieTotals.OrderDescending().Take(3).ToList().Sum();

Console.WriteLine(highestCalories);

Console.WriteLine(topThreeCalories);