using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerGraphLib;
using TigerGraphLib.Models;

namespace TigergraphCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        TgClient _TgClient;
        public HomeController(TgClient  tgClient)
        {
            _TgClient = tgClient;
        }

        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            // var r = await _TgClient.Vertices("friends", "person","123");
            //var data = JsonConvert.DeserializeObject<Upsert>(File.ReadAllText(o.File));
            //var r = await _TgClient.Upsert("friends",,true,false,true);
            return new JsonResult(r);
        }
    }
}
