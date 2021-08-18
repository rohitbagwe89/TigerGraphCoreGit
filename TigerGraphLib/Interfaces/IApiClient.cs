using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TigerGraphLib.Models;

namespace TigerGraphLib
{
    interface IApiClient
    {
        Task<T> RestHttpGetAsync<T>(string query);
    }
}
