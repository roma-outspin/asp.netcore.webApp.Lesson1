using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace lesson1
{
    internal class Post
    {

        public int userId { get; set; }

        public int id { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public override string ToString()
        {
            return $"{userId}\r\n" +
                $"{id}\r\n" +
                $"{title}\r\n" +
                $"{body}\r\n";
        }
    }
}
