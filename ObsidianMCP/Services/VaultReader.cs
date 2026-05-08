using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsidianMCP.Models;

namespace ObsidianMCP.Services
{
    public class VaultReader
    {
        /// <summary>
        /// Path to the obsidian vault.
        /// </summary>
        private readonly string _vaultPath;
        
        /// <summary>
        /// Default constructor. Set vault path instance variable.
        /// </summary>
        /// <param name="vaultPath"></param>
        public VaultReader(string vaultPath)
        {
            if (string.IsNullOrEmpty(vaultPath))
            {
                throw new ArgumentException("Vault path cannot be null or empty.", nameof(vaultPath));
            }
            if (!Directory.Exists(vaultPath))
            {
                throw new ArgumentException("Vault path does not exist.", nameof(vaultPath));
            }

            _vaultPath = vaultPath;
        }
        public async Task<Note> ReadNote(string notePath)
        {
            string fullPath = Path.Combine(_vaultPath, notePath);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Note not found at path: {fullPath}");
            }
            string title = Path.GetFileNameWithoutExtension(fullPath);
            string content = await File.ReadAllTextAsync(fullPath);

            NoteMetadata metadata = new(title, File.GetCreationTime(fullPath), []);
            return new Note(title, content, notePath, metadata);
        }

        public async Task<string[]> ListNotes()
        {
            return await Task.Run(() =>
            {
                var noteFiles = Directory.GetFiles(_vaultPath, "*.md", SearchOption.AllDirectories);
                return noteFiles.Select(f => Path.GetRelativePath(_vaultPath, f)).ToArray();
            });
        }

        public static async Task<NoteMetadata> GetNoteMetadata(Note note)
        {
            return await Task.Run(() =>
            {
                return note.Metadata;
            });
        }
    }
}
