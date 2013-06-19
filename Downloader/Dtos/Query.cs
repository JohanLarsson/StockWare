using Downloader.Dtos.DegugAndDiagnostics;

namespace Downloader.Dtos
{
    public class Query<TResult>
    {
        public int Count { get; set; }
        public string Created { get; set; }
        public string Lang { get; set; }
        public Diagnostics Diagnostics { get; set; }
        public TResult Results { get; set; }
    }
}