namespace Mmr.RestApi.Demo.Requests
{
    public class DataArgs
    {
        public IEnumerable<string>? Capabilities { get; set; }
        public IEnumerable<string>? Default { get; set; } 
        
        public DataArgs()
        {
            Default = ["this.default"];
        }
    }
}
