using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class CSVRecord
    {
        public int UserId { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}