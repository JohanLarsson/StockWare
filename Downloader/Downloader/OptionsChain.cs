using System.Collections.Generic;

namespace Downloader
{
    public class OptionsChain
    {
        public string symbol { get; set; }
        public List<Option> option { get; set; }
    }
}