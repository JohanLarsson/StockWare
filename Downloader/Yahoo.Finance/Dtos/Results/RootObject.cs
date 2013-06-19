namespace Downloader.Yahoo.Finance.Dtos.Results
{
    public class RootObject<TResult>
    {
        public Query<TResult> Query { get; set; }
    }
}