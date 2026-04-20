using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsidianMCP.Models
{
    internal class NoteMetadata(string title, DateTime createdDate, List<string> tags)
    {
        public string Title { get; set; } = title;
        public DateTime CreatedDate { get; set; } = createdDate;
        public List<string> Tags { get; set; } = tags;

    }
}
