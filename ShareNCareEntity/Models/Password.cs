using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareNCareEntity.Models
{
    public class Password
    {   
        [ForeignKey("User")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Secret { get; set; }

        public User User { get; set; }

    }
}
