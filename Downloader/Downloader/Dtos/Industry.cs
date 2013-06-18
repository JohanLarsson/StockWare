using System.Collections.Generic;
using Downloader.Dtos;

namespace Downloader.Downloaders
{
    public class Industry
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Company> company { get; set; }
    }
}