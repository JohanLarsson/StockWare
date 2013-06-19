using Downloader.Yahoo.Finance.Dtos.DebugAndDiagnostics;

namespace Downloader.Yahoo.Finance.Dtos.Results
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