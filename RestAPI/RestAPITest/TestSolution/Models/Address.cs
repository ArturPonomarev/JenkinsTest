using System;

namespace RestAPITest.TestSolution.Models
{
    public struct Address
    {
        public string Street { set; get; }
        public string Suite { set; get; }
        public string City { set; get; }
        public string Zipcode { set; get; }
        public Geo Geo { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is Address data)
                return (Street == data.Street
                        && Suite == data.Suite
                        && City == data.City
                        && Zipcode == data.Zipcode
                        && Geo.Equals(data.Geo));
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Suite, City, Zipcode, Geo);
        }
    }
}
