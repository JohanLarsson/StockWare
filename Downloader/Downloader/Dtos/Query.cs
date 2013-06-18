namespace Downloader.Dtos
{
    public class Query<TResult>
    {
        public int Count { get; set; }
        public string Created { get; set; }
        public string Lang { get; set; }
        public TResult Results { get; set; }
    }
}