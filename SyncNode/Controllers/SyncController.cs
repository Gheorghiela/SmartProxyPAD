using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncNode.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sync(SyncEntity entity)
        {
            return Ok();
        }
    }
}
