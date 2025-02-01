using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrueSound.Model
{
    public class SearchRes
    {
        public class Tracks
        {
            [JsonIgnore]
            public int totalCount { get; set; }
            public List<item>? items { get; set; }
            [JsonIgnore]
            public pagingInfo? pagingInfo { get; set; }
        }

        public class item
        {
            public data data { get; set; }
        }

        public class data
        {
            public string? uri { get; set; }
            public string? id { get; set; }
            public string? name { get; set; }

        }
        public class pagingInfo
        {
            public int nextOffset { get; set; }
            public int limit { get; set; }
        }
    }
}
