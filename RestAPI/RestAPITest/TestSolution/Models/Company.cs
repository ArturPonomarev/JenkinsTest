using System;

namespace RestAPITest.TestSolution.Models
{
    public struct Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Company data)
                return (Name == data.Name
                        && CatchPhrase == data.CatchPhrase
                        && Bs == data.Bs);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CatchPhrase, Bs);
        }
    }
}
