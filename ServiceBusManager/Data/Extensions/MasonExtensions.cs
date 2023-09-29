using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceBusManager.Data.Extensions
{
    public static class MasonExtensions
    {
        public static T DeepCopy<T>(this T t) where T : class
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(t, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            })) ?? throw new NullReferenceException($"Json Deserialization for type {t.GetType().FullName} failed.");
        }

    }
}
