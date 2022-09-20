using System;

namespace RestAPITest.TestSolution.Models
{
    public struct PostData
    {
        public int UserId { set; get; }
        public int Id { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is PostData data) 
                return (UserId == data.UserId 
                        && Id == data.Id
                        && Title == data.Title
                        && Body == data.Body);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, Id, Title, Body);
        }
    }
}
