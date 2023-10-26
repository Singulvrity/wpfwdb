using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfwdb
{
   public class Modules
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }  
        public int Credits { get; set; }
        public int ClassHours { get; set; }
    }
}
