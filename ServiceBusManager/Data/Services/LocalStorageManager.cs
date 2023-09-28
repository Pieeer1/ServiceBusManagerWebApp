using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServiceBusManager.Data.Models;
using ServiceBusManager.Data.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        public async Task<LocalSettings?> GetLocalSettings()
        {
            string settingsString = (await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.LocalSettings)).Value ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(settingsString))
            {
                try
                { 
                    return JsonSerializer.Deserialize<LocalSettings>(settingsString);
                }
                catch 
                {
                    await _protectedLocalStorage.DeleteAsync(LocalStorageKeys.SavedConnections); // Remove Corrupted Local Settings
                }
            }
            return null;
        }
        public async Task UpdateLocalSettings(LocalSettings localSettings)
        { 
            await _protectedLocalStorage.SetAsync(LocalStorageKeys.LocalSettings, JsonSerializer.Serialize(localSettings, new JsonSerializerOptions()
            { 
                ReferenceHandler = ReferenceHandler.IgnoreCycles // sets to null same as newtonsoft version
            }));
        }

        public async Task<Dictionary<string, string>> GetConnections()
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
        public async Task AddConnectionToLocalStorage(AddConnectionForm addConnectionForm)
        {
            var context = new ValidationContext(addConnectionForm);
            if (!Validator.TryValidateObject(addConnectionForm, context, null, true))
            {
                return;
            }
            if (!(await GetConnections()).ContainsKey(addConnectionForm.Name))
            {
                string? previousConnections = (await _protectedLocalStorage.GetAsync<string>(LocalStorageKeys.SavedConnections)).Value;
                await _protectedLocalStorage.SetAsync(LocalStorageKeys.SavedConnections, previousConnections == null ? $"{addConnectionForm.Name}={addConnectionForm.ConnectionString}" : $"{previousConnections},{addConnectionForm.Name}={addConnectionForm.ConnectionString}");
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
