using System;
using System.Collections.Generic;
using System.IO;

namespace UserLogin
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacNumber { get; set; }
        public int Role { get; set; }
        public DateTime Created;
        public DateTime DateValid;
    }
}
