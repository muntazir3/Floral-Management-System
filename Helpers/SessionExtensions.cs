using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Floral_Shop.Helpers
{
    public static class SessionExtensions
    {
        // Store an object in the session as a JSON string
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value)); // Ensure the object is not null
            session.SetString(key, JsonSerializer.Serialize(value));           // Serialize and store in session
        }

        // Retrieve and deserialize an object from the session
        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // Retrieve JSON string from session
            return string.IsNullOrEmpty(value) ? default : JsonSerializer.Deserialize<T>(value); // Deserialize or return default
        }
    }
}
