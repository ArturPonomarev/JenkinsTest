using RestAPITest.Framework.Utils;
using RestAPITest.TestSolution.Models;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.TestSolution.Utils
{
    public static class PostDataUtil
    {
        public static bool IsPostsSorted(PostData[] postsData)
        {
            LogInfo("Проверка на сортировку по возрастанию ID постов posts");
            int[] idArray = new int[postsData.Length];

            for (int i = 0; i < idArray.Length; ++i)
                idArray[i] = postsData[i].Id;

            return ArrayUtil.IsSortedAscending(idArray);
        }

        public static bool IsPostCorrect(PostData data, int correctPostId, int correctPostUserId)
        {
            LogInfo("Проверка на корректность данных поста posts/99");
            if (data.Id == correctPostId
                && data.UserId == correctPostUserId
                && data.Title.Length > 0
                && data.Body.Length > 0)
                return true;
            return false;
        }


        public static bool AreEqual(PostData data1, PostData data2)
        {
            return data1.Equals(data2);
        }
    }
}
