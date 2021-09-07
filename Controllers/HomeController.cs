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
            Upsert data = new Upsert();

            ValueTuple<string, object> arrayTuplefirst_name =  ("first_name", "Rohit");
            ValueTuple<string, object> arrayTuplelast_name = ("last_name", "Bagwe");
            ValueTuple<string, object> arrayTupleage = ("age", 61);
            ValueTuple<string, object> arrayTupleemail = ("email", "rtohitbagwe@yahoo.com");
            ValueTuple<string, object> arrayTuplegender = ("gender", "Male");
            data.AddVertexTypes("person");
            data.AddVertex("person", "4444");
            data.AddVertexAttributes("person","4444","", arrayTuplefirst_name, arrayTuplelast_name, arrayTupleage, arrayTupleemail, arrayTuplegender);

            var r = await _TgClient.Upsert("friends",data,true,false,true);
            return new JsonResult(r);
        }
    }
}
