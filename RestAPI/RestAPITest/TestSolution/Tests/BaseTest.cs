using NUnit.Framework;
using RestAPITest.TestSolution.Models;
using RestAPITest.Framework.Utils;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.TestSolution.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        private const string TestDataFilePath = "Resources/testData.json";
        private const string RequestDataFilePath = "Resources/requestData.json";

        protected TestData _testData = JSONUtil.DeserializeFile<TestData>(TestDataFilePath);
        protected RequestData _requestData = JSONUtil.DeserializeFile<RequestData>(RequestDataFilePath);

        [SetUp]
        public virtual void SetUp()
        {
            LogInfo("Начало теста");
        }

        [TearDown]
        public virtual void TearDown()
        {
            LogInfo("Окончание теста");
        }
    }
}
