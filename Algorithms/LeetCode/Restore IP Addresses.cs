using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 93. Restore IP Addresses
     * 
     * Given a string containing only digits, restore it by returning all possible valid IP address combinations.
     *
     *Example:
     *
     *Input: "25525511135"
     *Output: ["255.255.11.135", "255.255.111.35"]
     */
    public class RestoreIPAddresses
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            // Test cases:
            // s = "1001", output = ["1.0.0.1"]
            // s = "10001", output = ["10.0.0.1"]
            // So we know a string starts with '0' is invalid, such as "01".
            // The idea is similar to "Problem 91. Decode Ways".
            if (s.Length < 4) return new string[0];
            var first = new List<List<string>>()
            {
                new List<string>()
            };
            var second = new List<List<string>>()
            {
                new List<string>() { s.Substring(0,1) }
            };
            var third = new List<List<string>>()
            {
                new List<string>() { s.Substring(0, 1), s.Substring(1, 1) }
            };
            if (s[0] != '0') third.Add(new List<string>() { s.Substring(0, 2) });

            for (int i = 2; i < s.Length; i++)
            {
                var current = new List<List<string>>();
                BuildCurrent(s, current, first, i, 3);
                BuildCurrent(s, current, second, i, 2);
                BuildCurrent(s, current, third, i, 1);
                first = second;
                second = third;
                third = current;
            }
            return third.Where(ip => ip.Count == 4).Select(ip => string.Join('.', ip)).ToList();
        }

        private void BuildCurrent(string s, List<List<string>> current, List<List<string>> former, int i, int newIpBlockLength)
        {
            foreach (var ipBlocks in former)
            {
                // ((4 - (ipBlocks.Count + 1)) means how many more blocks do we need to get a valid IP address.
                // if the chars left is more than the potential longest IP address, we know it's not a valid answer.
                // For example: s = "123333333333"
                // And we have a partly-formed IP address: 1.2
                // The longest IP is only 1.2.333.333, shorter than s. 
                if ((4 - (ipBlocks.Count + 1)) * 3 >= s.Length - 1 - i)
                {
                    var newBlock = s.Substring(i - newIpBlockLength + 1, newIpBlockLength);
                    if ((!newBlock.StartsWith('0') || newBlock == "0") && int.Parse(newBlock) < 256)
                    {
                        current.Add(new List<string>(ipBlocks) { newBlock });
                    }
                }
            }
        }
    }
}
