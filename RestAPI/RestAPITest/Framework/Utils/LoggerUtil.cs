using Aquality.Selenium.Core.Logging;

namespace RestAPITest.Framework.Utils
{
    public static class LoggerUtils
    {
        public static void LogInfo(string message)
        {
            Logger.Instance.Info(message);
        }

        public static string GetClassName(object obj)
        {
            string[] name = obj.ToString().Split('.');
            return name[name.Length - 1];
        }
    }
}