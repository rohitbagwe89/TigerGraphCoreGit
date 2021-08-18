using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerGraphLib;

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
            var r = await _TgClient.Vertices("friends", "person","123");
            return new JsonResult(r);
        }
    }
}
