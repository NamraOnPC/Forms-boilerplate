using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROAssignment2.Models
{
    public class Book
    {

        public int bookID { get; set; }

        public String summary { get; set; }

        public String title { get; set; }

        public String libraryAddress { get; set; }

        public int libraryID { get; set; }
    }
}
