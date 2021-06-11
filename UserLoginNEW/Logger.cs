using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLoginNEW
{
    public static class Logger
    {
        private static List<string> currentSessionActivities  = new List<string>();

        public static void LogActivity(string activity) {
            //UserInfoContext context = new UserInfoContext();
            LogsContext context = new LogsContext();
            string activityLine = DateTime.Now + ";" + LoginValidation.currentUserUsername + ";" +
                                LoginValidation.CurrentUserRole + ";" + activity + "\n";

            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt") == true)    
            {
                File.WriteAllText("test.txt", activityLine);
            }
            if (File.Exists("log.txt") == true)
            {
                File.WriteAllText("log.txt", activityLine);
                Logs newLog = new Logs();
                context.Logs.Add(newLog);
            }
            context.SaveChanges();
        }

        public static void GetCurrentSessionActivities() {
            StringBuilder line = new StringBuilder();
            foreach (string activity in currentSessionActivities) {
                line.Append("\nCurrent activity: " + activity);
            }
            Console.WriteLine(line) ;
        }
        static public List<string> ReadFile()
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines("test.txt");
            foreach (string line in lines)
            {
                sb.Append(line + " \n");
            }
            List<string> loggs = sb.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return loggs;
        }
    }
}