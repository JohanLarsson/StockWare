using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace DownloaderTests.Prototypes
{
    [Explicit]
    class JsonSandbox
    {
        [Test]
        public void SerializePrivateTest()
        {
            var jsonDummy = new JsonDummy("public", "privateSet", "privateGet", "private");
            string json = JsonConvert.SerializeObject(jsonDummy);
            Console.WriteLine(json);
            JsonDummy deserialized = JsonConvert.DeserializeObject<JsonDummy>(json);
        }
    }

    public class JsonDummy
    {
        public JsonDummy(string publicProp, string privateSetProp, string privateGetProp, string privateProp)
        {
            PublicProp = publicProp;
            PrivateSetProp = privateSetProp;
            PrivateGetProp = privateGetProp;
            PrivateProp = privateProp;
        }

        public string PublicProp { get; set; }
        public string PrivateSetProp { get; private set; }
        public string PrivateGetProp { private get; set; }
        private string PrivateProp { get; set; }

    }
}
