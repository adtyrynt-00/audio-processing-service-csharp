using AudioProcessingService.Core.Models;

namespace AudioProcessingService.Core.Interfaces
{
    public interface IMLProcessor
    {
        string Analyze(AudioMetadata audio);
    }
}
