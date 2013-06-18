using System.IO;
using Newtonsoft.Json;

namespace DownloaderTests
{
    public static class SerializerExt
    {
        private static readonly JsonSerializer _serializer;

        static SerializerExt()
        {
            _serializer = JsonSerializer.Create(new JsonSerializerSettings());
            _serializer.MissingMemberHandling = MissingMemberHandling.Error;
        }

        public static T Deserialize<T>(this string json)
        {

            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                var deserialize = _serializer.Deserialize<T>(reader);
                return deserialize;
            }

        }
    }
}