using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNEW
{
    public class Logs
    {   
        public int LogsId { get; set; }
        public DateTime? Date { get; set; }
        public string Activity { get; set; }
        public string Username { get; set; }
        public UserRoles Role { get; set; }
        public Logs(string username, UserRoles role, string activity) 
        {
            this.Date = DateTime.Now;
            this.Activity = activity;
            this.Username = username;
            this.Role = role;
        }
        public Logs() 
        { 
        }

        public override string ToString()
        {
            return Date + "/" + Username + "/" + Role + "/" + Activity;
        }
    }
}
