using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNEW
{
    class LogsContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }
        public LogsContext() : base(Properties.Settings.Default.DbConnect) 
        {
        }
    }
}
