using RestAPITest.TestSolution.Models;

namespace RestAPITest.TestSolution.Utils
{
    public static class UserDataUtil
    {
        public static UserData FindById(UserData[] usersData, int id)
        {
            foreach (UserData data in usersData)
            {
                if (data.Id == id)
                    return data;
            }
            return default;
        }
        

        public static bool AreEqual(UserData data1, UserData data2)
        {
            return data1.Equals(data2);
        }
    }
}
