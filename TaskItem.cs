using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ai_chatttt
{
    public class TaskItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        public bool Completed { get; set; }

        public override string ToString()
        {
            string status = Completed ? "✅ Completed" : "🟢 Pending";

            string reminder = Reminder.HasValue
                ? Reminder.Value.ToString("dd MMM yyyy")
                : "No Reminder";

            return $"📌 {Title}\n" +
                   $"📝 {Description}\n" +
                   $"📅 Reminder: {reminder}\n" +
                   $"{status}";
        }
    }
}