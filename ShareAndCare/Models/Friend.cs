using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareAndCare.Models
{
    public class Friend
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public int FriendId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
