using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareAndCare.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Msg { get; set; }
    }
}
