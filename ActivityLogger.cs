using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_chatttt
{
    public class ActivityLogger
    {
        private List<string> activityLog = new List<string>();

        public void AddLog(string action)
        {
            activityLog.Add($"{DateTime.Now:HH:mm} - {action}");
        }

        public List<string> GetRecentLogs()
        {
            List<string> recentLogs = new List<string>();

            int startIndex = Math.Max(0, activityLog.Count - 10);

            for (int i = activityLog.Count - 1; i >= startIndex; i--)
            {
                recentLogs.Add(activityLog[i]);
            }

            return recentLogs;
        }

        public List<string> GetAllLogs()
        {
            return activityLog;
        }
    }
}
