using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfwdb
{
    public class Semesters
    {
        //This will be the Semester table
        [Key]
        public int SemesterId { get; set; }
        public string Name { get; set; }
        public int Weeks { get; set; }
        public DateTime StartDate { get; set; }
    }
}
