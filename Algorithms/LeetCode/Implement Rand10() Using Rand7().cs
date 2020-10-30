namespace Algorithms.LeetCode
{
    /* 470. Implement Rand10() Using Rand7()
     * 
     * Given the API rand7() that generates a uniform random integer in the range [1, 7], write a function
     * rand10() that generates a uniform random integer in the range [1, 10]. You can only call the API
     * rand7(), and you shouldn't call any other API. Please do not use a language's built-in random API.
     * 
     * Follow up:
     * 
     * What is the expected value for the number of calls to rand7() function?
     * Could you minimize the number of calls to rand7()?
     */
    public class Implement_Rand10_Using_Rand7
    {
        public abstract class Solution
        {
            public int Rand10()
            {
                // Rejection Sampling: https://leetcode.com/problems/implement-rand10-using-rand7/solution/
                int result;
                do
                {
                    result = 7 * (Rand7() - 1) + (Rand7() - 1);
                } while (result >= 40);
                return result % 10 + 1;
            }

            public abstract int Rand7();
        }
    }
}
