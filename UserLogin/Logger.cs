using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities  = new List<string>();

        public static void LogActivity(string activity) {

            string activityLine = DateTime.Now + ";" + LoginValidation.currentUserUsername + ";" +
                                LoginValidation.CurrentUserRole + ";" + activity + "\n";

            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt") == true)    
            {
                File.AppendAllText("test.txt", activityLine);
            }

        }

        public static void GetCurrentSessionActivities() {
            StringBuilder line = new StringBuilder();
            foreach (string activity in currentSessionActivities) {
                line.Append("\nCurrent activity: " + activity);
            }
            Console.WriteLine(line) ;

        }
    }
}
