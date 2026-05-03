using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsidianMCP.Models
{
    internal class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string NotePath { get; set; }
        public NoteMetadata Metadata { get; set; }

        public Note(string title, string content, string notePath, NoteMetadata metadata)
        {
            Title = title;
            Content = content;
            NotePath = notePath;
            Metadata = metadata;
        }
    }

    public override string ToString()
    {
            return this.Content;
      
    }
}
