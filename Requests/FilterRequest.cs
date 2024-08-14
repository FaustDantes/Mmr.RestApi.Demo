namespace Mmr.RestApi.Demo.Requests
{
    public class FilterRequest<T> where T : class
    {
        public T? Datas { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
