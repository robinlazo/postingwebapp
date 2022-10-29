namespace SocialMedia.Models;
using Newtonsoft.Json;
public static class SessionExtensions {
    public static void SetObject<T>(this ISession session, string key, T value) {
        string data = JsonConvert.SerializeObject(value);
        session.SetString(key, data);
    }


    public static T GetObject<T>(this ISession session, string key) {
        var obj = session.GetString(key);

        return obj == null ? default(T) : JsonConvert.DeserializeObject<T>(obj);
    }
}