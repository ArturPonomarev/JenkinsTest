using System;

namespace RestAPITest.Framework.Utils
{
    public static class ArrayUtil
    {
        private const int CompareLesserResult = -1;

        public static bool IsSortedAscending<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; ++i)
                if (array[i].CompareTo(array[i - 1]) == CompareLesserResult)
                    return false;
            return true;
        }
    }
}
