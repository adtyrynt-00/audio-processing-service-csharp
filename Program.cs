using AudioProcessingService.Core.Models;
using AudioProcessingService.Core.Interfaces;
using AudioProcessingService.Infrastructure.ML;
using AudioProcessingService.Infrastructure.Database;

class Program
{
    static void Main()
    {
        IMLProcessor mlProcessor = new DummyMLProcessor();
        var repository = new AudioRepository();

        var audio = new AudioMetadata
        {
            FileName = "sample.wav",
            Duration = 3.5,
            SampleRate = 44100
        };

        var result = mlProcessor.Analyze(audio);
        Console.WriteLine(result);

        repository.Save(audio);
        Console.WriteLine("Audio metadata saved to database.");
    }
}
