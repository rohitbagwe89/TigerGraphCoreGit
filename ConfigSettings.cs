using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigergraphCoreAPI
{
    public class ConfigSettings
    {
        public string TG_REST_SERVER_URL { get; set; }
        public string TG_GSQL_SERVER_URL { get; set; }
        public string TG_USER { get; set; }
        public string TG_PSW { get; set; }
        public string TG_Token { get; set; }
    }
}
