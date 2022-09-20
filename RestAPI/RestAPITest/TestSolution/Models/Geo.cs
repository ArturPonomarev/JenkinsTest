using System;

namespace RestAPITest.TestSolution.Models
{
    public struct Geo
    {
        public string Lat { set; get; }
        public string Lng { set; get; }

        public override bool Equals(object obj)
        {
            if (obj is Geo data)
                return (Lat == data.Lat
                        && Lng == data.Lng);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lat, Lng);
        }
    }
}
