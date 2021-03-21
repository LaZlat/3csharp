using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareAndCare.Models
{
    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public String Username { get; set; }
        public ICollection<File> Files { get; set; } = new Collection<File>();
        public ICollection<Friend> Friends { get; set; } = new Collection<Friend>();
        public ICollection<Message> Msg { get; set; } = new Collection<Message>();
        public Password Password { get; set; } = new Password();
    }
}
