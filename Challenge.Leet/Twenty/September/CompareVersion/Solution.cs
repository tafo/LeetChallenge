using System;
using System.Collections.Generic;

namespace Challenge.Leet.Twenty.September.CompareVersion
{
    public class Solution
    {
        public int CompareVersion(string version1, string version2)
        {
            var versionPartList1 = GetVersionDigits(version1);
            var versionPartList2 = GetVersionDigits(version2);
            var length = Math.Min(versionPartList1.Count, versionPartList2.Count);

            for (var i = 0; i < length; i++)
            {
                if (versionPartList1[i] > versionPartList2[i])
                {
                    return 1;
                }

                if (versionPartList1[i] < versionPartList2[i])
                {
                    return -1;
                }
            }

            if (versionPartList1.Count > versionPartList2.Count)
            {
                return 1;
            }

            if (versionPartList1.Count < versionPartList2.Count)
            {
                return -1;
            }

            return 0;

            static List<int> GetVersionDigits(string input)
            {
                var result = input.Split('.');
                var output = new List<int>();
                for (var i = 0; i < result.Length; i++)
                {
                    var versionPart = result[i];
                    if (versionPart.Length == 0) continue;

                    versionPart = versionPart.TrimStart('0');
                    if (versionPart.Length == 0) versionPart = "0";
                    result[i] = versionPart;
                }

                var flag = true;
                for (var i = result.Length - 1; i >= 0; i--)
                {
                    var versionPart = int.Parse(result[i]);
                    if (versionPart == 0 && flag) continue;

                    flag = false;
                    output.Add(versionPart);
                }

                output.Reverse();
                return output;
            }
        }
    }
}