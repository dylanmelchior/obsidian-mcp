using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsidianMCP.Services
{
    internal class VaultWriter
    {
            /// <summary>
            /// Path to the obsidian vault.
            /// </summary>
            private readonly string _vaultPath;
            
            /// <summary>
            /// Default constructor. Set vault path instance variable.
            /// </summary>
            /// <param name="vaultPath"></param>
            public VaultWriter(string vaultPath)
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
}
