using System;
using System.Collections.Generic;
using System.Text;

namespace TigerGraphLib.Models
{
    public class EdgesResult
    {
        public ServerVersion version { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public Edge[] results { get; set; }
    }

    public class Edge
    {
        public string e_type { get; set; }
        public bool directed { get; set; }
        public string from_id { get; set; }
        public string from_type { get; set; }
        public string to_id { get; set; }
        public string to_type { get; set; }
        public int? count { get; set; }
        public EdgeAttributes attributes { get; set; }
    }

    public class EdgeAttributes {}

    public class EdgesCountResult
    {
        public Version version { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public EdgesCount[] results { get; set; }
    }

    public class EdgesCount
    {
        public string e_type { get; set; }
        public int count { get; set; }
    }
}
