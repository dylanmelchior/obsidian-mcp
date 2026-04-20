using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsidianMCP.Models
{
    internal class Note(string title, string content, string notePath, NoteMetadata metadata)
    {
        public string Title { get; set; } = title;
        public string Content { get; set; } = content;
        public string NotePath { get; set; } = notePath;
        public NoteMetadata Metadata { get; set; } = metadata;
    }
}
