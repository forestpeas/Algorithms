namespace Algorithms.LeetCode
{
    /* 1286. Iterator for Combination
     * 
     * Design an Iterator class, which has:
     * 
     * A constructor that takes a string characters of sorted distinct lowercase English letters and a number
     * combinationLength as arguments.
     * A function next() that returns the next combination of length combinationLength in lexicographical order.
     * A function hasNext() that returns True if and only if there exists a next combination.
     * 
     * Example:
     * 
     * CombinationIterator iterator = new CombinationIterator("abc", 2); // creates the iterator.
     * 
     * iterator.next(); // returns "ab"
     * iterator.hasNext(); // returns true
     * iterator.next(); // returns "ac"
     * iterator.hasNext(); // returns true
     * iterator.next(); // returns "bc"
     * iterator.hasNext(); // returns false
     */
    public class CombinationIterator
    {
        private readonly string _characters;
        private readonly int[] _combIdx;
        private bool _end = false;

        public CombinationIterator(string characters, int combinationLength)
        {
            _characters = characters;
            _combIdx = new int[combinationLength];
            for (int i = 0; i < _combIdx.Length; i++)
            {
                _combIdx[i] = i;
            }
        }

        public string Next()
        {
            string result = string.Empty;
            foreach (int idx in _combIdx)
            {
                result += _characters[idx];
            }

            // Similar to "77. Combinations".
            // Move to the next combination.
            int i = _combIdx.Length - 1;
            while (_combIdx[i] == _characters.Length - (_combIdx.Length - i))
            {
                if (i == 0)
                {
                    _end = true;
                    return result;
                }
                i--;
            }

            _combIdx[i]++;

            while (i < _combIdx.Length - 1)
            {
                i++;
                _combIdx[i] = _combIdx[i - 1] + 1;
            }

            return result;
        }

        public bool HasNext()
        {
            return !_end;
        }
    }

}
