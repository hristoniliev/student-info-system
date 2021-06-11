using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace UserLoginNEW
{
    public class User
    {
        public System.String Username { get; set; }
        public System.String Password { get; set; }
        public System.String FacNumber { get; set; }
        public System.Int32 Role { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime? DateValid { get; set; }
        public System.Int32 UserId { get; set; }
        
    }
}
