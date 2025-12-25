using AudioProcessingService.Core.Interfaces;
using AudioProcessingService.Core.Models;

namespace AudioProcessingService.Infrastructure.ML
{
    public class DummyMLProcessor : IMLProcessor
    {
        public string Analyze(AudioMetadata audio)
        {
            return $"Audio '{audio.FileName}' processed for ML inference.";
        }
    }
}
