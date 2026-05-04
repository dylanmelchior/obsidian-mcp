using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsidianMCP.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;
using ObsidianMCP.Models;

namespace ObsidianMCP.Tools
{
    [McpServerToolType]
    public class ObsidianTools(VaultReader reader, VaultWriter writer, SearchService searchService)
    {
        private readonly VaultReader reader = reader;
        private readonly VaultWriter writer = writer;
        private readonly SearchService searchService = searchService;

        [McpServerTool, Description("Get a list of all notes in the vault.")]
        public async Task<List<string>> ListNotes()
        {
            List<string> fileNames = [];
            string[] notePaths = await reader.ListNotes();
            foreach (string notePath in notePaths)
            {
                fileNames.Add(Path.GetFileName(notePath));
            }
            return fileNames;
        }

        [McpServerTool, Description("Read a note.")]
        public async Task<string> ReadNote(string fileName)
        {
            try
            {
                Note note = await reader.ReadNote(fileName);
                return note.Content;
            }
            catch (FileNotFoundException)
            {
                return "Could not find file: " + fileName;
            }
        }

        [McpServerTool, Description("Search the vault for notes.")]
        public async Task<List<string>> GetMatchingNotePaths(string searchParameter)
        {
            List<string> matchingPaths = await searchService.FindMatchingPaths(searchParameter);
            return matchingPaths;
        }
    }
}
