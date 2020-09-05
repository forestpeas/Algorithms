using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 385. Mini Parser
     * 
     * Given a nested list of integers represented as a string, implement a parser to deserialize it.
     * 
     * Each element is either an integer, or a list -- whose elements may also be integers or other lists.
     * 
     * Note: You may assume that the string is well-formed:
     * 
     * String is non-empty.
     * String does not contain white spaces.
     * String contains only digits 0-9, [, - ,, ].
     * 
     * Example 1:
     * 
     * Given s = "324",
     * 
     * You should return a NestedInteger object which contains a single integer 324.
     * 
     * Example 2:
     * 
     * Given s = "[123,[456,[789]]]",
     * 
     * Return a NestedInteger object containing a nested list with 2 elements:
     * 
     * 1. An integer containing value 123.
     * 2. A nested list containing two elements:
     *     i.  An integer containing value 456.
     *     ii. A nested list with one element:
     *          a. An integer containing value 789.
     */
    public class Mini_Parser
    {
        public NestedInteger Deserialize(string s)
        {
            var parent = new NestedInteger();
            var stack = new Stack<NestedInteger>();
            int? num = null;
            int sign = 1;
            foreach (char c in s)
            {
                if (c == '[')
                {
                    var list = new NestedInteger();
                    parent.Add(list);
                    stack.Push(parent);
                    parent = list;
                }
                else if (c == ']' || c == ',')
                {
                    if (num.HasValue)
                    {
                        parent.Add(new NestedInteger(num.Value * sign));
                        num = null;
                        sign = 1;
                    }
                    if (c == ']') parent = stack.Pop();
                }
                else if (c == '-')
                {
                    sign = -1;
                }
                else
                {
                    num ??= 0;
                    num = num * 10 + (c - '0');
                }
            }

            if (num.HasValue) parent.Add(new NestedInteger(num.Value * sign));
            return parent.GetList()[0];
        }

        public class NestedInteger
        {
            // Constructor initializes an empty nested list.
            public NestedInteger() { }

            // Constructor initializes a single integer.
            public NestedInteger(int value) { }

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni) => throw new NotImplementedException();

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            public IList<NestedInteger> GetList() => throw new NotImplementedException();
        }
    }
}
