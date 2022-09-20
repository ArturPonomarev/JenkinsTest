using NUnit.Framework;
using RestAPITest.TestSolution.Models;
using RestAPITest.Framework.Utils;
using RestAPITest.Framework.Wrappers;
using RestAPITest.TestSolution.Utils;
using System.Net;
using static RestAPITest.Framework.Utils.LoggerUtils;
using RestSharp;

namespace RestAPITest.TestSolution.Tests
{
    [TestFixture]
    class JSONPlaceHolderAPITest : BaseTest
    {
        private const string EmptyResponse = "{}";

        private const int CorrectPostId = 99;
        private const int IncorrectPostId = 150;
        private const int CorrectPostUserId = 10;
        private const int RandomPostUserId = 1;
        private const int RandomPostBodyLength = 5;
        private const int RandomPostTitleLength = 7;
        private const int RandomPostId = 101;
        private const int CheckingUserId = 5;

        private RestResponse _getResponse;
        private RestResponse _postResponse;

        [Test]
        public void TestMethod()
        {
            RestClientAdvanced.SetApiUrl(_testData.TestApiLink);

            LogInfo($"{GetClassName(this)} - Step 1 - Check get request for all posts");
            _getResponse = RestUtil.GetRequest(_testData.RequestResources.AllPosts);
            Assert.AreEqual(_getResponse.StatusCode, HttpStatusCode.OK, "Posts response status code is not 200");
            Assert.IsTrue(RestUtil.IsResponseJson(_getResponse),"Posts responce body is not JSON");
            Assert.IsTrue(PostDataUtil.IsPostsSorted(RestUtil.ConverResponseTo<PostData[]>(_getResponse)),"Posts are not sorted by Id");


            LogInfo($"{GetClassName(this)} - Step 2 - Check get request for post/99");
            _getResponse = RestUtil.GetRequest(string.Format(_testData.RequestResources.SinglePost,CorrectPostId));
            Assert.AreEqual(_getResponse.StatusCode, HttpStatusCode.OK, "Post/99 response status code is not 200");
            Assert.IsTrue(PostDataUtil.IsPostCorrect(RestUtil.ConverResponseTo<PostData>(_getResponse), CorrectPostId, CorrectPostUserId), 
                          "Post/99 user id is not 10 OR id is not 99 OR title is empty OR body is empty");


            LogInfo($"{GetClassName(this)} - Step 3 - Check get request for post/150");
            _getResponse = RestUtil.GetRequest(string.Format(_testData.RequestResources.SinglePost, IncorrectPostId));
            Assert.AreEqual(_getResponse.StatusCode, HttpStatusCode.NotFound, "post/150 response status code is not 404");
            Assert.IsTrue(_getResponse.Content == EmptyResponse, "post/150 responce body is not empty");


            LogInfo($"{GetClassName(this)} - Step 4 - POST request with random data");
            PostData randomPostdata = new PostData {
                UserId = RandomPostUserId,
                Body = StringUtil.GetRandomString(RandomPostBodyLength),
                Title = StringUtil.GetRandomString(RandomPostTitleLength) };
            _postResponse = RestUtil.PostRequest(_testData.RequestResources.AllPosts, JSONUtil.Serialize(randomPostdata));
            Assert.AreEqual(_postResponse.StatusCode, HttpStatusCode.Created, "POST response status code is not 201");
            randomPostdata.Id = RandomPostId;
            Assert.IsTrue(PostDataUtil.AreEqual(randomPostdata,RestUtil.ConverResponseTo<PostData>(_postResponse)),"Api post is not random post");


            LogInfo($"{GetClassName(this)} - Step 5 - GET request for check all users data");
            _getResponse = RestUtil.GetRequest(_testData.RequestResources.AllUsers);
            Assert.AreEqual(_getResponse.StatusCode, HttpStatusCode.OK, "users response status code is not 200");
            Assert.IsTrue(RestUtil.IsResponseJson(_getResponse), "users response body is not JSON");
            UserData responceUserData = UserDataUtil.FindById(RestUtil.ConverResponseTo<UserData[]>(_getResponse), CheckingUserId);
            Assert.IsTrue(UserDataUtil.AreEqual(responceUserData, _requestData.UserData),"UserData(id = 5) is not correct");


            LogInfo($"{GetClassName(this)} - Step 6 - GET request for check single user data");
            _getResponse = RestUtil.GetRequest(string.Format(_testData.RequestResources.SingleUser, CheckingUserId));
            Assert.AreEqual(_getResponse.StatusCode, HttpStatusCode.OK, "single user response status code is not 200");
            Assert.IsTrue(UserDataUtil.AreEqual(responceUserData, RestUtil.ConverResponseTo<UserData>(_getResponse)),
                            "users/5 user data dont matches with user data in previous step");
        }
    }
}
