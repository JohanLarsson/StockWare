namespace Downloader.Dtos
{
    public class RootObject<TResult>
    {
        public Query<TResult> Query { get; set; }
    }
}