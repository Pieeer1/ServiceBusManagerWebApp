﻿using ServiceBusManager.Data.Models.Attributes;

namespace ServiceBusManager.Data.Models
{
    public record class LocalSettings
    {
        [FriendlyName("Close Send Message Modal After Send?")]
        public bool AutoCloseOnMessageSend { get; set; }
        [FriendlyName("Save Connections?")]
        public bool SaveConnections { get; set; } = true;
    }
}
