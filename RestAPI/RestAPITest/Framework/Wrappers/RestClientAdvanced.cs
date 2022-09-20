using RestSharp;
using System;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Wrappers
{
    class RestClientAdvanced
    {
        private static RestClient _instance;

        private RestClientAdvanced() { }

        public static RestClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RestClient();
                return _instance;
            }
        }

        public static void SetApiUrl(string url)
        {
            LogInfo($"Установка ссылки на клиента ссылки: {url}");
            Instance.Options.BaseUrl = new Uri(url);
        }

        public static string GetApiUrl()
        {
            return Instance.Options.BaseUrl.ToString();
        }
    }
}
