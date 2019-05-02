namespace Algorithms.Strings
{
    public class KMP
    {
        public int Search(string haystack, string needle)
        {
            int[] next = new int[needle.Length];
            InitNext(next, needle);

            int i = 0;
            int j = 0;
            while (i < haystack.Length && j < needle.Length)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else if (j == 0)
                {
                    i++;
                }
                else
                {
                    j = next[j];
                }
            }

            if (j == needle.Length)
            {
                return i - j;
            }
            return -1;
        }

        private void InitNext(int[] next, string needle)
        {
            int i = 1;
            int j = 0;
            while (i < needle.Length)
            {
                if (needle[i] == needle[j])
                {
                    i++;
                    j++;
                    if (i < needle.Length) next[i] = j;
                }
                else if (j == 0)
                {
                    i++;
                }
                else
                {
                    j = next[j];
                }
            }
        }
    }
}
