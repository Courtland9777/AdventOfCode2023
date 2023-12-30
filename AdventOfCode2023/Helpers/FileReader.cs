namespace AdventOfCode2023.Helpers;

public class FileReader
{
    public static string[] ReadLines(string filePath) =>
        File.ReadAllLines(filePath);

    public static string[] ReadInput(string day)
    {
        // Get the relative path of the input.txt file for the specified day
        var inputPath = Path.Combine($"Day_{day}", "input.txt");
        // Read the file lines into an array
        var input = File.ReadAllLines(inputPath);
        return input;
    }

    public static string ReadInputToString(int day)
    {
        if (day is > 25 or < 1)
            throw new ArgumentOutOfRangeException(nameof(day),
                $"Day is {day} and can't be greater than 25 or less than 1.");
        return string.Join('\n', File.ReadAllLines(Path.Combine($"Day_{day}", "input.txt")));
    }
}