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
    [ApiController]
    [Route("[controller]")]
    public class ShareCareController : ControllerBase
    {
        private TheContext dataContext;
        private readonly ILogger<WeatherForecastController> _logger;


        public ShareCareController(TheContext context, ILogger<WeatherForecastController> logger)
        {
            dataContext = context;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetMessages()
        {
            List<Message> result = dataContext.Messages.ToList<Message>();

            if (result != null) { return Ok(JsonConvert.SerializeObject(result,Formatting.Indented)); }
            else { return NotFound(); }
        }

        [HttpGet("[action]/{username}")]
        public IActionResult GetFiles(string username)
        {
            var result = dataContext.Users.Where(a => a.Username == username).Select(a => a.Files).FirstOrDefault();

            if (result != null) {
                return Ok(JsonConvert.SerializeObject(result,Formatting.Indented)); }
            else { return NotFound(); }
        }

        [HttpGet("[action]/{username}&{id}")]
        public IActionResult GetNotFriends(string username, int id)
        {
            if (id != dataContext.Users.Where(a => a.Username == username).Select(a => a.Id).FirstOrDefault()) { throw new Exception("Wrong ID"); }

            var smth = dataContext.Users.Where(a => a.Username == username).SelectMany(a => a.Friends);
            var qq = smth.Select(x => x.FriendId).ToList();
            List<User> result = dataContext.Users.Where(p => !qq.Contains(p.Id)).Where(c => c.Id != id).ToList();

            if (result != null) { return Ok(JsonConvert.SerializeObject(result,Formatting.Indented)); }
            else { return NotFound(); }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetFriendsFiles(int id)
        {
            var smth = dataContext.Users.Where(a => a.Id == id).SelectMany(a => a.Friends);
            var qq = smth.Select(x => x.FriendId).ToList();
            var result = dataContext.Users.Where(a => qq.Contains(a.Id)).SelectMany(a => a.Files);

            if (result != null) { return Ok(JsonConvert.SerializeObject(result,Formatting.Indented)); }
            else { return NotFound(); }
        }

        [HttpPost("[action]")]
        public IActionResult PostUser([FromBody] JsonElement value)
        {
            string json = value.GetRawText();
            NewUser temp = JsonConvert.DeserializeObject<NewUser>(json);

            User newOne = new User { Username = temp.Username };
            newOne.Password.Secret = temp.Password;
            dataContext.Add(newOne);
            dataContext.SaveChanges();

            return Ok();
        }

        [HttpPut("[action]/{username}")]
        public IActionResult PutMessage (string username, [FromBody] JsonElement value)
        {
            string json = value.GetRawText();
            Message temp = JsonConvert.DeserializeObject<Message>(json);

            var user = dataContext.Users.Where(s => s.Username == username).SingleOrDefault();

            if (user == null) { return NotFound(); }

            user.Msg.Add(temp);
            dataContext.Update(user);
            dataContext.SaveChanges();

            return Ok();
        }

        [HttpPut("[action]/{username}")]
        public IActionResult PutFriend(string username, [FromBody] JsonElement value)
        {
            string json = value.GetRawText();
            Friend temp = JsonConvert.DeserializeObject<Friend>(json);

            var user = dataContext.Users.Where(s => s.Username == username).SingleOrDefault();
            if (user == null) { return StatusCode(500); }

            var friend = dataContext.Users.Where(x => x.Id == temp.FriendId).FirstOrDefault();
            if (friend == null) { throw new Exception("Not existing user for a friend"); }

            user.Friends.Add(temp);
            dataContext.Update(user);
            dataContext.SaveChanges();

            return Ok();
        }

        [HttpPut("[action]/{username}")]
        public IActionResult PutFile(string username, [FromBody] JsonElement value)
        {
            string json = value.GetRawText();
            File temp = JsonConvert.DeserializeObject<File>(json);

            var user = dataContext.Users.Where(s => s.Username == username).SingleOrDefault();

            if (user == null) { return NotFound(); }

            user.Files.Add(temp);

            dataContext.Update(user);
            dataContext.SaveChanges();

            return Ok();
        }
 
        [HttpPatch("[action]/{username}")]
        public IActionResult PatchUsersPassword(string username, [FromBody] JsonElement value)
        {
            var json = value.GetRawText();
            NewOldPass temp = JsonConvert.DeserializeObject<NewOldPass>(json);

            var user = dataContext.Users.Where(s => s.Username == username).Where(p => p.Password.Secret == temp.Old).SingleOrDefault();
            
            if (user == null) { return NotFound(); }

            user.Password.Secret = temp.Neu;
            var pass = dataContext.Passwords.Where(s => s.Id == user.Id).SingleOrDefault();
            pass.Secret = temp.Neu;

            dataContext.Update(user);
            dataContext.Update(pass);
            dataContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var file = dataContext.Files.Where(c => c.Id == id).SingleOrDefault();

            if (file == null) { return NotFound(); }

            dataContext.Files.Remove(file);
            dataContext.SaveChanges();

            return Ok();
        }
    }
}
