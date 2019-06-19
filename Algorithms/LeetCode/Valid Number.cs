namespace Algorithms.LeetCode
{
    /* 65. Valid Number
     * 
     * Validate if a given string can be interpreted as a decimal number.
     * 
     * Some examples:
     * "0" => true
     * " 0.1 " => true
     * "abc" => false
     * "1 a" => false
     * "2e10" => true
     * " -90e3   " => true
     * " 1e" => false
     * "e3" => false
     * " 6e-1" => true
     * " 99e2.5 " => false
     * "53.5e93" => true
     * " --6 " => false
     * "-+3" => false
     * "95a54e53" => false
     * 
     * Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one. 
     * However, here is a list of characters that can be in a valid decimal number:
     * 
     * Numbers 0-9
     * Exponent - "e"
     * Positive/negative sign - "+"/"-"
     * Decimal point - "."
     * Of course, the context of these characters also matters in the input.
     */
    public class ValidNumber
    {
        public bool IsNumber(string s)
        {
            // I think the point of this problem is that we should write enough test cases.
            // Note that some of the official test cases are not so rigorous: https://leetcode.com/problems/valid-number/discuss/23741/The-worst-problem-i-have-ever-met-in-this-oj/23036
            s = s.Trim();
            if (s.Length < 1) return false;
            int i = (s[0] == '+' || s[0] == '-') ? 1 : 0;
            if (i == s.Length) return false; // There must be a digit or a dot.
            bool foundE = false;
            if (s[i] == '.') // Jump to where a dot has been found.
            {
                // Nothing follows the dot. Or s = ".e"
                if (i + 1 == s.Length || s[i + 1] == 'e' || s[i + 1] == 'E') return false;
            }
            else
            {
                if (!char.IsDigit(s[i])) return false; // At least one digit exists.
                i++;
                while (i < s.Length && char.IsDigit(s[i])) i++;
                if (i == s.Length) return true; // There were only digits.
                if (s[i] == 'e' || s[i] == 'E')
                {
                    foundE = true;
                    if (i + 1 < s.Length && (s[i + 1] == '+' || s[i + 1] == '-')) i++;
                    if (i + 1 == s.Length) return false; // There must be at least one digit after "e"
                }
                else if (s[i] != '.')
                {
                    return false;
                }
            }
            i++;
            while (i < s.Length && char.IsDigit(s[i])) i++;
            if (i == s.Length) return true; // There were only digits.
            if (foundE) return false; // Found two 'e's.
            if (s[i] == 'e' || s[i] == 'E')
            {
                if (i + 1 < s.Length && (s[i + 1] == '+' || s[i + 1] == '-')) i++;
            }
            else return false;
            i++;
            if (i == s.Length) return false; // There must be at least one digit after the last non-digit char.
            while (i < s.Length)
            {
                if (!char.IsDigit(s[i])) return false;
                i++;
            }
            return true;
        }
    }
}
