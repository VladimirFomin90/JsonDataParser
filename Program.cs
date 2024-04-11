using System.Text.Json;

string fileContent = default;
bool isFileRead = false;
string fileName = default;

do
{
    try
    {
        Console.WriteLine("Enter the name of file which you want to read:");
        fileName = Console.ReadLine();

        fileContent = File.ReadAllText(fileName);
        isFileRead = true;
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine("The name of file cannot be null");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("The name of file cannot be empty");
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("There is no file with that name");
    }
} while (!isFileRead);

List<VideoGame> videoGames = default;

try
{
    videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
}
catch (JsonException ex)
{
    var originalConsoleColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Json in {fileName} file was not in a valid format. JSON body:");
    Console.WriteLine(fileContent);
    Console.ForegroundColor = originalConsoleColor;
    
    throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
}

if (videoGames.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine("Loaded games are:");

    foreach (var videoGame in videoGames)
    {
        Console.WriteLine(videoGame);
    }
}
else
{
    Console.WriteLine("No games in this file");
}

Console.ReadKey();

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => $"Title: {Title}, release in {ReleaseYear}, rating: {Rating}";
}