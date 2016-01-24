using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptainsLog.Core
{

    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

    }
}
