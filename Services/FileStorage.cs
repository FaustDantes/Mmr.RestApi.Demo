namespace Mmr.RestApi.Demo.Services
{
    public class FileStorage : IFileStorage
    {
        private readonly string _code;
        public FileStorage(string code) {
            _code = code;
        }

        public void PrintCode()
        {
         //   Console.WriteLine("FS code >"+_code);
        }
    }
}
