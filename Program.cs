using System.Net;
using System.Text.Json;

Console.WriteLine("Enter the name of file which you want to read:");
var fileName = Console.ReadLine();

var fileContent = File.ReadAllText(fileName);

var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);

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