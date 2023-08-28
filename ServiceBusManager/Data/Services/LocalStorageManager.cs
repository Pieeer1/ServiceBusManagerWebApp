﻿using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServiceBusManager.Data.Services.Interfaces;
using System.Text.RegularExpressions;
using static ServiceBusManager.Data.Extensions.Constants;

namespace ServiceBusManager.Data.Services
{
    public class LocalStorageManager : ILocalStorageManager
    {
        private ProtectedLocalStorage _protectedLocalStorage;

        public LocalStorageManager(ProtectedLocalStorage protectedLocalStorage)
        {
            _protectedLocalStorage = protectedLocalStorage;
        }
        public async Task<Dictionary<string,string>> GetConnections() 
        {
            Dictionary<string, string> connections = new Dictionary<string, string>();
            string unparsedConnectionStrings = (await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.SavedConnections)).Value ?? string.Empty;
            Regex re = new Regex(@"([^,)]*=[^,]*)", RegexOptions.Multiline);

            foreach (string parseableConnection in re.Matches(unparsedConnectionStrings).Select(x => x.Groups[1].Value))
            {
                connections.Add(parseableConnection.Split("=")[0], string.Join('=', parseableConnection.Split("=").Select((x, i) => { if (i > 0) { return x; } return string.Empty; }))[1..]);
            }
            return connections;
        }
        public async Task AddConnectionToLocalStorage(string name, string connectionString)
        {
            if (!(await GetConnections()).ContainsKey(name))
            {
                string? previousConnections = (await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.SavedConnections)).Value;
                await _protectedLocalStorage.SetAsync(LocalStorageKeys.SavedConnections, previousConnections == null ? $"{name}={connectionString}" : $"{previousConnections},{name}={connectionString}");
            }
        }

        public async Task RemoveConnectionFromLocalStorage(string name)
        {
            string? previousConnections = (await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.SavedConnections)).Value;
            if (string.IsNullOrWhiteSpace(previousConnections))
            {
                await _protectedLocalStorage.DeleteAsync(LocalStorageKeys.SavedConnections);
            }
            else
            {
                Regex deleteRegex = new Regex(@$"({name}=[^,]*),*", RegexOptions.Multiline);
                string modifiedString = $"{deleteRegex.Replace(previousConnections, string.Empty)}";
                await _protectedLocalStorage.SetAsync(LocalStorageKeys.SavedConnections, modifiedString);
            }
        }

    }
}