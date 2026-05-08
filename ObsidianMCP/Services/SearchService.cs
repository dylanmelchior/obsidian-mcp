using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObsidianMCP.Services
{
    public class SearchService
    {
        private readonly string _vaultPath;
        public SearchService(string vaultPath)
        { 
            _vaultPath = vaultPath;
        }

        public async Task<List<string>> FindMatchingPaths(string searchParameter)
        {
            return await Task.Run(() =>
            {
                Regex rg = new(Regex.Escape(searchParameter) + @"\.md$", RegexOptions.IgnoreCase);
                List<string> matchingPaths = [];
                foreach (string path in Directory.EnumerateFiles(_vaultPath, "*.md", SearchOption.AllDirectories))
                {
                    if (rg.IsMatch(path))
                    {
                        matchingPaths.Add(path);
                    }
                }
                return matchingPaths;
            });
        }
    }
}
