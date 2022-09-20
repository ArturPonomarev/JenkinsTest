using RestAPITest.Framework.Wrappers;
using RestSharp;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Utils
{
    public static class RestUtil
    {
        private const string JsonTitle = "application/json";

        public static RestResponse GetRequest(string requestParam)
        {
            LogInfo($"GET запрос по url:{RestClientAdvanced.GetApiUrl()}, параметра:{requestParam}");
            RestRequest request = new RestRequest(requestParam,Method.Get);
            return RestClientAdvanced.Instance.Get(request);
        }

        public static RestResponse PostRequest(string requestParam, string jsonBody)
        {
            LogInfo($"POST запрос по url:{RestClientAdvanced.GetApiUrl()}, параметра:{requestParam}");
            RestRequest request = new RestRequest(requestParam,Method.Post);
            request.AddJsonBody(jsonBody);
            return RestClientAdvanced.Instance.Post(request);
        }
        
        public static T ConverResponseTo<T>(RestResponse response)
        {
            return JSONUtil.DeserializeData<T>(response.Content);
        }

        public static bool IsResponseJson(RestResponse response)
        {
            return response.ContentType.Contains(JsonTitle);
        }
    }
}
