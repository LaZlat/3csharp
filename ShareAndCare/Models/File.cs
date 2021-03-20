using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareAndCare.Models
{
    public class File
    {
        public int Id { get; set; }

        public String FileName { get; set; }

        public String FilePath { get; set; }
    }
}
