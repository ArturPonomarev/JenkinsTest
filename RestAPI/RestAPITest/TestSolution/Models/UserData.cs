using System;

namespace RestAPITest.TestSolution.Models
{
    public struct UserData
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public Address Address { set; get; }
        public string Phone { set; get; }
        public string Website { set; get; }
        public Company Company { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is UserData data)
                return (Id == data.Id
                        && Name == data.Name
                        && UserName == data.UserName
                        && Email == data.Email
                        && Address.Equals(data.Address)
                        && Phone == data.Phone
                        && Website == data.Website
                        && Company.Equals(data.Company));
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, UserName, Email, Address, Phone, Website, Company);
        }
    }
}
