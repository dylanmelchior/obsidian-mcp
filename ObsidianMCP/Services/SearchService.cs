using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ObsidianMCP.Services
{
    internal class SearchService
    {
        private readonly string _vaultPath;
        public SearchService(string vaultPath)
        { 
            _vaultPath = vaultPath;
        }

        public List<string> findMatchingPaths(string searchParameter)
        {
            Regex rg = new Regex(searchParameter + ".md$");
            List<string> matchingPaths = [];
            foreach(string path in Directory.EnumerateFiles(_vaultPath, "*.md", SearchOption.AllDirectories))
            {
                if (rg.IsMatch(path))
                {
                    matchingPaths.Add(path);
                }
            }
            return matchingPaths;
        }
    }
}
