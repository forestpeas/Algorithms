namespace Algorithms.Strings
{
    public class LSD
    {
        // Least-significant-digit first (LSD) string sort based on key-indexed counting.
        public static void Sort(string[] array, int stringLength)
        {
            int R = 256; // R-character alphabet.
            string[] aux = new string[array.Length];

            for (int d = stringLength - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    count[array[i][d] + 1]++;
                }

                for (int i = 0; i < R; i++)
                {
                    count[i + 1] += count[i];
                }

                for (int i = 0; i < array.Length; i++)
                {
                    aux[count[array[i][d]]++] = array[i];
                }

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = aux[i];
                }
            }
        }
    }
}
