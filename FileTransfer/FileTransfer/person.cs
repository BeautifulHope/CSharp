using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon2
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }

    public class FileAction
    {
        public int id { get; set; }
        public string filename { get; set; }
        public string action { get; set; }
        public string time { get; set; }
    }
}
