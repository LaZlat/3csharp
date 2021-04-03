using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareNCareEntity.Models
{
    public class File
    {

        public File() 
        { 
        }
        public File(int _id, string _name, string _path)
        {
            Id = _id;
            FileName = _name;
            FilePath = _path;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public String FileName { get; set; }
        [Required]
        [StringLength(128)]
        public String FilePath { get; set; }
    }
}
