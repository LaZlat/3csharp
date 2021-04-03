using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareNCareEntity.DataContext;
using ShareNCareEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShareWebAPI.Controllers
{
    public class ShareCareUsersController : Controller
    {
        private TheContext dataContext;
        public ShareCareUsersController(TheContext data) { dataContext = data; }
        public IActionResult Get()
        {
            var result = dataContext.Users.ToList();
            if (result != null) { return Ok(JsonConvert.SerializeObject(result, Formatting.Indented)); }
            else
            {
                return NotFound();
            }
        }
    }
}
