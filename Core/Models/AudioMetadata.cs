namespace AudioProcessingService.Core.Models
{
    public class AudioMetadata
    {
        public string FileName { get; set; }
        public double Duration { get; set; }
        public int SampleRate { get; set; }
    }
}
