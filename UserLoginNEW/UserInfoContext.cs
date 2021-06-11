using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNEW
{
   public class UserInfoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserInfoContext() : base(Properties.Settings.Default.DbConnect) 
        {
        }
    }
}
