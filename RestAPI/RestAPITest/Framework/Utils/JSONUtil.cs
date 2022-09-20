using Newtonsoft.Json;
using System.IO;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Utils
{
    public static class JSONUtil
    {
        public static T DeserializeFile<T>(string path)
        {
            LogInfo($"Десериализация файла: {path} в объект: {typeof(T)}");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public static T DeserializeData<T>(string data)
        {
            LogInfo($"Десериализация в объект:{typeof(T)}");
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string Serialize<T>(T data)
        {
            LogInfo($"Сериализация из объекта:{typeof(T)}");
            return JsonConvert.SerializeObject(data);
        }
    }
}